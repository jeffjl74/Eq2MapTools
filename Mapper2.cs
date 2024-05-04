using System.Text;
using System.Text.RegularExpressions;

namespace EQ2MapTools
{
    internal class Mapper2
    {
        public static readonly Regex reLoc = new Regex(@"Your location is (?<lon>[0-9,.+-]+), (?<alt>[0-9,.+-]+), (?<lat>[0-9,.+-]+).  Your");
        static readonly Regex reStyle = new Regex("Map style name: (.+)", RegexOptions.Compiled);
        static readonly Regex reColor = new Regex(@"\\/a color (\w+)", RegexOptions.Compiled);
        static readonly Regex reColorBlack = new Regex(@"\\/a color\.$", RegexOptions.Compiled);

        static string version = "2.0";

        static string svgheader = "<?xml version=\"1.0\" standalone=\"no\"?>\n"
            + "<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\"\n"
            + "  \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">\n"
            + "<svg\n"
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
        (double x, double y) max_x = (-99999, 0);
        (double x, double y) max_y = (0, -99999);
        (double x, double y) min_x = (99999, 0);
        (double x, double y) min_y = (0, 99999);
        double max_z = -99999;
        double min_z = 99999;
        double avg_z = 0;
        int line_points = 0;
        double page_width = 744;    // as defined by Inkscape
        double page_height = 1050;  // as defined by Inkscape
        string current_color = "black";
        string map_style_name = "No Map Style Name Found";


        public static void GenerateCleanLog(string inputFile, string outputFile, bool append)
        {
            StringBuilder sb = new StringBuilder();
            if (append)
            {
                string exists = ReadAllLinesNonBlocking(outputFile);
                if (exists != null && !string.IsNullOrEmpty(exists))
                    sb.Append(exists);
            }
            using (StreamReader sr = File.OpenText(inputFile))
            {
                string? line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    Match match = reLoc.Match(line);
                    if (match.Success)
                        sb.AppendLine(line);
                    else if (line.Contains("\\/a start new map line"))
                        sb.AppendLine(line);
                    else if (reColor.Match(line).Success)
                        sb.AppendLine(line);
                    else if (reColorBlack.Match(line).Success)
                        sb.AppendLine(line);
                    else if (line.Contains("\\/a mapgroup"))
                        sb.AppendLine(line);
                    else if (reStyle.Match(line).Success)
                        sb.AppendLine(line);
                }
            }
            File.WriteAllText(outputFile, sb.ToString());
        }

        private static string ReadAllLinesNonBlocking(string path)
        {
            StringBuilder sb = new StringBuilder();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
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
            return sb.ToString();
        }

        // emulate Perl's .= and array auto-vivification
        private void Vivification(int index, string value)
        {
            while (index >= group_data.Count)
                group_data.Add(string.Empty);
            group_data[index] = group_data[index] + value;
        }

        private void FinishLine()
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
                    avg_z = 0;
                    line_points = 0;
                }
                // add the current line to the current group
                Vivification(current_group, $"::{current_color}&{current_line}");
                current_line = string.Empty;
            }
        }

        public void GenerateSvg(string inputFile, string outputFile, string elevations)
        {
            // get any elevation breaks
            List<string> els = elevations.Split(" ").ToList();
            if (els.Count > 0)
            {
                slices = new List<double>();
                foreach (string slice in els)
                {
                    double val;
                    if (double.TryParse(slice, out val))
                        slices.Add(val);
                }
                slices.Sort();
            }

            // process log lines
            List<string> logIn = File.ReadLines(inputFile).ToList();
            foreach (string logLine in logIn)
            {
                Match match = reStyle.Match(logLine);
                if (match.Success)
                    map_style_name = match.Groups[1].Value;

                else if (logLine.Contains("\\/a start new map line"))
                {
                    FinishLine();
                }
                else if (logLine.Contains("\\/a mapgroup"))
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
                    if (x > max_x.x) max_x = (x, y);
                    if (y > max_y.y) max_y = (x, y);
                    if (x < min_x.x) min_x = (x, y);
                    if (y < min_y.y) min_y = (x, y);
                    if (z < min_z) min_z = z;
                    if (z > max_z) max_z = z;

                    avg_z += z;
                    line_points++;

                    current_line += $"{x},{y},";
                }
            }
            // finish the last line
            FinishLine();

            // build crosshairs
            string extents_lines = $"::blue&{min_x.x},{min_y.y - Math.Abs(max_x.x - min_x.x) * .025},{min_x.x},{min_y.y + Math.Abs(max_x.x - min_x.x) * .025},";
            extents_lines += $"::blue&{min_x.x - Math.Abs(max_x.x - min_x.x) * .025},{min_y.y},{min_x.x + Math.Abs(max_x.x - min_x.x) * .025},{min_y.y},";
            extents_lines += $"::blue&{max_x.x},{max_y.y + Math.Abs(max_x.x - min_x.x) * .025},{max_x.x},{max_y.y - Math.Abs(max_x.x - min_x.x) * .025},";
            extents_lines += $"::blue&{max_x.x + Math.Abs(max_x.x - min_x.x) * .025},{max_y.y},{max_x.x - Math.Abs(max_x.x - min_x.x) * .025},{max_y.y},";

            group_data.Insert(0, extents_lines);

            double x_scale = page_width / Math.Abs(max_x.x - min_x.x);
            double y_scale = page_height / Math.Abs(max_y.y - min_y.y);
            double scale_factor = x_scale <= y_scale ? x_scale : y_scale;
            scale_factor *= .95;	 // Scale it so it doesn't hit the edges.

            double x_center = max_x.x - Math.Abs(max_x.x - min_x.x) / 2;
            double y_center = max_y.y - Math.Abs(max_y.y - min_y.y) / 2;

            string prefix = string.Empty;
            List<string> maplines = new List<string>();
            int group_num = 0;
            int line_count = 0;

            StringBuilder outfile = new StringBuilder();
            outfile.Append(svgheader);
            foreach (string group in group_data)
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
            outfile.AppendLine($"  <text x=\"10\" y=\"{page_height}\" font-family=\"Verdana\" font-size=\"18\" fill=\"black\" >");
            outfile.AppendLine($"    <tspan fill=\"blue\">UL: </tspan>{-min_x.x},{min_y.y}");
            outfile.AppendLine($"    <tspan fill=\"blue\">LR: </tspan>{-max_x.x},{max_y.y}");
            outfile.AppendLine($"    <tspan fill=\"blue\" dx=\"20\">Max Ele:</tspan> {max_z}");
            outfile.AppendLine($"    <tspan fill=\"blue\">Min Ele:</tspan> {min_z}");
            outfile.AppendLine("  </text>");
            outfile.Append(endgroup);

            outfile.AppendLine("</svg>");

            File.WriteAllText(outputFile, outfile.ToString());
        }
    }
}
