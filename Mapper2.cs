using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace EQ2MapTools
{
    internal class Mapper2
    {
        public static readonly Regex reLoc = new Regex(@"Your location is (?<lon>[0-9,.+-]+), (?<alt>[0-9,.+-]+), (?<lat>[0-9,.+-]+).  Your");
        public static readonly Regex reStyle = new Regex("Map style name: (?<style>.+)", RegexOptions.Compiled);
        public static readonly Regex reZoned = new Regex(@"] You have entered (?<zone>.+)\.$", RegexOptions.Compiled);
        public static readonly Regex reSvgName = new Regex(@"(?<name>.+)_(?<index>\d+)\.svg", RegexOptions.Compiled);
        static readonly Regex reColor = new Regex(@"\\/a color (\w+)", RegexOptions.Compiled);
        static readonly Regex reColorBlack = new Regex(@"\\/a color\.$", RegexOptions.Compiled);

        static string version = "2.0";

        static double page_width = 744;    // as defined by Inkscape (@May2024 - not sure where these come from, is not a standard size)
        static double page_height = 1050;  // as defined by Inkscape

        static string svgheader = "<?xml version=\"1.0\" standalone=\"no\"?>\n"
            + "<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\"\n"
            + "  \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">\n"
            + "<svg\n"
            + $"   width=\"{page_width}\"\n"
            + $"   height=\"{page_height}\"\n"
            + "   xmlns = \"http://www.w3.org/2000/svg\" version=\"1.1\"\n"
            + "   xmlns:inkscape=\"http://www.inkscape.org/namespaces/inkscape\">\n";
        static string startline = "<path fill=\"none\" stroke=\"{0}\" stroke-width=\"2\" \nd=\"";
        static string startgroup = "<g inkscape:label=\"{0}\" inkscape:groupmode=\"layer\" id=\"{1}\">\n";
        static string endgroup = "</g>\n\n";
        int current_group = 0;
        int total_groups = 0;
        List<string> group_data = new List<string>();
        string current_line = string.Empty;
        List<double> slices = new List<double>();
        double avg_z = 0;
        int line_points = 0;
        string current_color = "black";
        string map_style_name = "No Map Style Name Found";

        // add support for splitting into separate SVG files based on elevation
        internal class MinMaxRecord
        {
            public double min_x = double.MaxValue;
            public double max_x = double.MinValue;
            public double min_y = double.MaxValue;
            public double max_y = double.MinValue;
            public double min_z = double.MaxValue;
            public double max_z = double.MinValue;
            public double x_extent {
                get { return Math.Abs(max_x - min_x); }
            }
            public double y_extent
            {
                get { return Math.Abs(max_y - min_y); }
            }

            public void Reset()
            {
                min_x = double.MaxValue;
                max_x = double.MinValue;
                min_y = double.MaxValue;
                max_y = double.MinValue;
                min_z = double.MaxValue;
                max_z = double.MinValue;
            }
            public void Track(double x, double y, double z)
            {
                if (x < min_x) min_x = x;
                if (x > max_x) max_x = x;
                if (y < min_y) min_y = y;
                if (y > max_y) max_y = y;
                if (z < min_z) min_z = z;
                if (z > max_z) max_z = z;
            }
            public void Merge(MinMaxRecord other)
            {
                if (other.min_x < min_x) min_x = other.min_x;
                if (other.max_x > max_x) max_x = other.max_x;
                if (other.min_y < min_y) min_y = other.min_y;
                if (other.max_y > max_y) max_y = other.max_y;
                if (other.min_z < min_z) min_z = other.min_z;
                if (other.max_z > max_z) max_z = other.max_z;
            }
        }
        MinMaxRecord currentMinMax = new MinMaxRecord();
        List<MinMaxRecord> minMaxRecords = new List<MinMaxRecord>();
        public List<string> svgFileNames = new List<string>();


        public static void GenerateCleanLog(string inputFile, string outputFile, bool append, Int64 startTime, Int64 endTime)
        {
            StringBuilder sb = new StringBuilder();
            if (append)
            {
                using (FileStream fs = new FileStream(outputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string? line = sr.ReadLine();
                            if (line != null)
                                sb.AppendLine(line);
                        }
                    }
                }
            }
            using (FileStream fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string? line = String.Empty;
                    string? lastZoneName = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // timestamp filter
                        if(line.Length < 39)
                            continue;
                        Int64 lineTime;
                        if (!Int64.TryParse(line.Substring(1, 10), out lineTime))
                            continue;
                        if(lineTime < startTime || lineTime > endTime)
                            continue;

                        Match match = reLoc.Match(line);
                        if (match.Success)
                            sb.AppendLine(line);
                        else if (line.Contains("\\/a start new map line"))
                            sb.AppendLine(line);
                        else if (reColor.Match(line).Success)
                            sb.AppendLine(line); // the original Perl script would accept any two words if the first one was "color"
                        else if (reColorBlack.Match(line).Success)
                            sb.AppendLine(line); // this line was not properly recognized by the original Perl script
                        else if (line.Contains("\\/a mapgroup"))
                            sb.AppendLine(line);
                        else if (reStyle.Match(line).Success)
                        {
                            sb.AppendLine(lastZoneName); // so we can set the "displayname=" when building a mapstyles.xml element
                            sb.AppendLine(line);
                        }
                        else if (reZoned.Match(line).Success)
                            lastZoneName = line; // this line was not part of the original Perl script
                    }
                }
            }
            File.WriteAllText(outputFile, sb.ToString());
        }

        // emulate Perl's array auto-vivification
        private void DataVivification(int index, string value)
        {
            while (index >= group_data.Count)
                group_data.Add(string.Empty);
            // also doing Perl's .=
            group_data[index] = group_data[index] + value;
        }

        private void FinishLine(bool multipleFiles)
        {
            if (!string.IsNullOrEmpty(current_line))
            {
                if (slices.Count > 0 && line_points > 0)
                {
                    // determine to which group this line belongs
                    avg_z /= line_points;
                    int i = 0;
                    for (; i < slices.Count; i++)
                    {
                        if (slices[i] > avg_z)
                            break;
                    }
                    current_group = i;
                    if (multipleFiles)
                    {
                        minMaxRecords[current_group].Merge(currentMinMax);
                        currentMinMax.Reset();
                    }
                    else
                        minMaxRecords[0].Merge(currentMinMax);
                    avg_z = 0;
                    line_points = 0;
                }
                else
                    minMaxRecords[0].Merge(currentMinMax);
                // add the current line to the current group
                DataVivification(current_group, $"::{current_color}&{current_line}");
                current_line = string.Empty;
            }
        }

        public void GenerateSvg(string inputFile, string outputFile, string elevations, bool multipleFiles)
        {
            // get any elevation breaks
            slices = new List<double>();
            char[] separators = new char[] { ' ', ',' };
            List<string> els = elevations.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (els.Count > 0)
            {
                foreach (string slice in els)
                {
                    double val;
                    if (double.TryParse(slice, out val))
                        slices.Add(val);
                }
                slices.Sort();
            }
            for(int i = 0; i <= slices.Count; i++)
                minMaxRecords.Add(new MinMaxRecord());
            if(slices.Count == 0)
                multipleFiles = false;

            // process log lines
            List<string> logIn = File.ReadLines(inputFile).ToList();
            foreach (string logLine in logIn)
            {
                Match match = reStyle.Match(logLine);
                if (match.Success)
                    map_style_name = match.Groups[1].Value;

                else if (logLine.Contains("\\/a start new map line"))
                {
                    FinishLine(multipleFiles);
                }
                else if (logLine.Contains("\\/a mapgroup") && slices.Count == 0)
                {
                    current_group = ++total_groups;
                }
                else if ((match = reColor.Match(logLine)).Success)
                {
                    current_color = match.Groups[1].Value;
                }
                else if ((match = reColorBlack.Match(logLine)).Success)
                {
                    current_color = "black";
                }
                else if ((match = reLoc.Match(logLine)).Success)
                {
                    double x = double.Parse(match.Groups[1].Value);
                    double z = double.Parse(match.Groups[2].Value);
                    double y = double.Parse(match.Groups[3].Value);

                    // invert the sign for x
                    x *= -1;

                    // save min/max values
                    currentMinMax.Track(x, y, z);

                    avg_z += z;
                    line_points++;

                    current_line += $"{x},{y},";
                }
            }
            // finish the last line
            FinishLine(multipleFiles);

            svgFileNames.Clear();
            if(multipleFiles)
            {
                // need to construct file names with incrementing "map level"
                string svgName;
                int fileNum = 0;
                Match match = reSvgName.Match(outputFile);
                if (match.Success)
                {
                    // base name ends with a number, start with that
                    svgName = match.Groups["name"].Value;
                    fileNum = int.Parse(match.Groups["index"].Value);
                }
                else
                {
                    // has no number at the end, will just add one
                    svgName = outputFile.Replace(".svg", "");
                }
                // build an svg for each elevation group
                for (int index=0; index<group_data.Count; index++, fileNum++)
                {
                    string outFile = svgName + "_" + fileNum.ToString() + ".svg";
                    CreateSvgFile(inputFile, outFile, index, 1);
                    svgFileNames.Add(outFile);
                }
            }
            else
            {
                CreateSvgFile(inputFile, outputFile, 0, group_data.Count);
                svgFileNames.Add(outputFile);
            }
        }

        private void CreateSvgFile(string inputFile, string outputFile, int index, int gcount)
        {
            MinMaxRecord mmr = minMaxRecords[index]; //shorthand name
            // build crosshairs
            string extents_lines = $"::blue&{mmr.min_x},{mmr.min_y - mmr.x_extent * .025},{mmr.min_x},{mmr.min_y + mmr.x_extent * .025},";
            extents_lines += $"::blue&{mmr.min_x - mmr.x_extent * .025},{mmr.min_y},{mmr.min_x + mmr.x_extent * .025},{mmr.min_y},";
            extents_lines += $"::blue&{mmr.max_x},{mmr.max_y + mmr.x_extent * .025},{mmr.max_x},{mmr.max_y - mmr.x_extent * .025},";
            extents_lines += $"::blue&{mmr.max_x + mmr.x_extent * .025},{mmr.max_y},{mmr.max_x - mmr.x_extent * .025},{mmr.max_y},";

            List<string> groups = new List<string>();
            groups.Add(extents_lines);
            for(int i = index; i < index+gcount; i++) 
                groups.Add(group_data[i]);

            double x_scale = page_width / mmr.x_extent;
            double y_scale = page_height / mmr.y_extent;
            double scale_factor = x_scale <= y_scale ? x_scale : y_scale;
            scale_factor *= .95;	 // Scale it so it doesn't hit the edges.

            double x_center = mmr.max_x - mmr.x_extent / 2;
            double y_center = mmr.max_y - mmr.y_extent / 2;

            string prefix = string.Empty;
            List<string> maplines = new List<string>();
            int group_num = 0;
            int line_count = 0;

            StringBuilder outfile = new StringBuilder();
            outfile.Append(svgheader);
            foreach (string group in groups)
            {
                maplines = group.Split("::").ToList();
                // start the group
                outfile.Append(string.Format(startgroup, $"group_{group_num}", "layer" + group_num));
                group_num++;

                foreach (string line in maplines)
                {
                    string[] dat = line.Split('&');
                    if (dat.Length == 2)
                    {
                        string color = dat[0];
                        string line_data = dat[1];
                        if (string.IsNullOrEmpty(line_data))
                            continue; // skip blank lines

                        prefix = "M";
                        outfile.Append(string.Format(startline, color));

                        // break each line into its coordinates, scale them, and export them
                        string[] cords = line_data.Split(',');
                        for (int count = 0; count < cords.Length; count += 2)
                        {
                            double c1, c2;
                            if (double.TryParse(cords[count], out c1) && double.TryParse(cords[count + 1], out c2))
                            {
                                double x = (c1 - x_center) * scale_factor + page_width / 2;
                                double y = (c2 - y_center) * scale_factor + page_height / 2;
                                outfile.Append($"{prefix}{x:F2},{y:F2}");
                                prefix = "L";
                            }
                        }
                        line_count++;
                        outfile.Append($"\" \nid=\"NewLine{line_count}\"/>\n\n");
                    }
                }
                outfile.Append(endgroup); // Close the group
            }

            // text group
            outfile.Append(string.Format(startgroup, $"layer{group_num}", "text_group")); // start the group
            outfile.AppendLine("  <text x=\"10\" y=\"20\" font-family=\"Verdana\" font-size=\"18\" fill=\"blue\" >");
            outfile.AppendLine($"    Mapper2 v{version} - {inputFile}");
            outfile.AppendLine("  </text>");
            outfile.AppendLine("  <text x=\"10\" y=\"40\" font-family=\"Verdana\" font-size=\"18\" fill=\"blue\" >");
            outfile.AppendLine($"    Map Style Name: {map_style_name}");
            outfile.AppendLine("  </text>");
            outfile.AppendLine($"  <text x=\"10\" y=\"{page_height - 3}\" font-family=\"Verdana\" font-size=\"18\" fill=\"black\" >");
            outfile.AppendLine($"    <tspan fill=\"blue\">UL: </tspan>{-mmr.min_x},{mmr.min_y}");
            outfile.AppendLine($"    <tspan fill=\"blue\">LR: </tspan>{-mmr.max_x},{mmr.max_y}");
            outfile.AppendLine($"    <tspan fill=\"blue\" dx=\"20\">Max Ele:</tspan> {mmr.max_z}");
            outfile.AppendLine($"    <tspan fill=\"blue\">Min Ele:</tspan> {mmr.min_z}");
            outfile.AppendLine("  </text>");
            outfile.Append(endgroup);

            outfile.AppendLine("</svg>");

            File.WriteAllText(outputFile, outfile.ToString());
        }
    }
}
