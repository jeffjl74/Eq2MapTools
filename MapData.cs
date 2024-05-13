using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace EQ2MapTools
{
    public class MapData : INotifyPropertyChanged
    {

        // properties bound to textboxes

        private string _zonerect = string.Empty;
        public string zonerect
        {
            get => _zonerect;
            set => SetField(ref _zonerect, value);
        }

        private double _crosshairAX = double.NaN;
        public double crosshairAX
        {
            get => _crosshairAX;
            set => SetField(ref _crosshairAX, value);
        }

        private double _crosshairAY = double.NaN;
        public double crosshairAY
        {
            get => _crosshairAY;
            set => SetField(ref _crosshairAY, value);
        }

        private double _crosshairBX = double.NaN;
        public double crosshairBX
        {
            get=> _crosshairBX;
            set => SetField(ref _crosshairBX, value);
        }

        private double _crosshairBY = double.NaN;
        public double crosshairBY
        {
            get => _crosshairBY;
            set => SetField(ref _crosshairBY, value);
        }

        private double _imageWidth = Form1.DefaultMapWidth;
        public double imageWidth
        {
            get => _imageWidth;
            set => SetField(ref _imageWidth, value);
        }

        private double _imageHeight = Form1.DefaultMapHeight;
        public double imageHeight
        {
            get => _imageHeight;
            set => SetField(ref _imageHeight, value);
        }


        private string _UL = string.Empty;
        public string UL
        {
            get => _UL;
            set
            {
                _UL = value;
                Match match = reLocs.Match(value);
                if (match.Success)
                {
                    ULX = double.Parse(match.Groups["x"].Value);
                    ULY = double.Parse(match.Groups["y"].Value);
                }
            }
        }

        private double _ULX = double.NaN;
        public double ULX
        {
            get => _ULX;
            set => SetField(ref _ULX, value);
        }

        private double _ULY = double.NaN;
        public double ULY
        {
            get => _ULY;
            set => SetField(ref _ULY, value);
        }

        private string _LR = string.Empty;
        public string LR
        {
            get => _LR;
            set
            {
                _LR = value;
                Match match = reLocs.Match(value);
                if (match.Success)
                {
                    LRX = double.Parse(match.Groups["x"].Value);
                    LRY = double.Parse(match.Groups["y"].Value);
                }
            }
        }

        private double _LRX = double.NaN;
        public double LRX
        {
            get => _LRX;
            set => SetField(ref _LRX, value);
        }

        private double _LRY = double.NaN;
        public double LRY
        {
            get => _LRY;
            set => SetField(ref _LRY, value);
        }

        public double inputScaleWidth = 436;
        public double inputScaleHeight = 506;

        public string? vertA;                   // the upper left vertical crosshair svg string
        public string? vertB;                   // the lower right vertical crosshair svg string
        public string? horzA;                   // the upper left horizontal crosshair svg string
        public string? horzB;                   // the lower right horizontal crosshair svg string
        public double svgFactor;                // calucalted scaling factor to fit the svg to the image
        public bool adjustedX;                  // scaling factor if we scale for X
        public bool adjustedY;                  // scaling factor if we scale for Y
        public string MaxEl = string.Empty;     // elevation svg string
        public string MinEl = string.Empty;     // elevation svg string

        // intermediate calculations
        private double LOC0x, LOC0y, LOC1x, LOC1y, wdppx, wdppy;
        private double svgXextent, svgYextent;

        // log line matching
        Regex reNewLine = new Regex("M(?<x1>[0-9.+-]+),(?<y1>[0-9.+-]+)L(?<x2>[0-9.+-]+),(?<y2>[0-9.+-]+)", RegexOptions.Compiled);
        Regex reNewLineInk = new Regex(@"[Mm]\s*(?<x1>[0-9.+-]+),(?<y1>[0-9.+-]+)\s*(?<dir>[hHvV])\s*(?<dest>[0-9.+-]+)", RegexOptions.Compiled);
        Regex reLocs = new Regex(@"(?<x>[0-9.+-]+),\s*(?<y>[0-9.+-]+)");

        // textbox binding support
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            Debug.WriteLine($"{propertyName} set to {value}");
            return true;
        }

        public void CalcCrosshairs()
        {
            // find the width for the svg file
            double x1 = Math.Max(ExtractX1(horzB), ExtractX2(horzB));
            double x2 = Math.Min(ExtractX1(horzA), ExtractX2(horzA));
            svgXextent = Math.Round(x1 - x2, 0);

            // find the height for the svg file
            double y1 = Math.Max(ExtractY1(vertB), ExtractY2(vertB));
            double y2 = Math.Min(ExtractY1(vertA), ExtractY2(vertA));
            svgYextent = Math.Round(y1 - y2, 0);

            Debug.WriteLine($"SVG width:{svgXextent}; SVG height:{svgYextent}");

            // try changing the scaling of X and Y to see which is a better fit
            double leftoverY = 0;
            double leftoverX = 0;
            double changedXfactor = imageWidth / svgXextent;
            double resultingY = Math.Round(svgYextent * changedXfactor, 0);
            double changedYfactor = imageHeight / svgYextent;
            double resultingX = Math.Round(svgXextent * changedYfactor, 0);
            // if scaling either X or Y works, choose the better one
            bool xIsBetter = false;
            bool yIsBetter = false;
            if (resultingX <= imageWidth && resultingY <= imageHeight)
            {
                double yUnused = imageHeight - resultingY;
                double xUnused = imageWidth - resultingX;
                Debug.WriteLine($"both scales work x-dir={xUnused}, y-dir={yUnused}");
                if (yUnused < xUnused)
                    yIsBetter = true;
                else
                    xIsBetter = true;
            }
            if (resultingX <= imageWidth && !yIsBetter)
            {
                Debug.WriteLine($"divided by height, got {changedYfactor}: {resultingX},{imageHeight}");
                inputScaleHeight = imageHeight;
                inputScaleWidth = resultingX;
                svgFactor = changedYfactor;
                leftoverX = imageWidth - resultingX;
                adjustedX = true;
            }
            if (resultingY <= imageHeight && !xIsBetter)
            {
                Debug.WriteLine($"divided by width, got {changedXfactor}: {imageWidth},{resultingY}");
                inputScaleWidth = imageWidth;
                inputScaleHeight = resultingY;
                svgFactor = changedXfactor;
                leftoverY = imageHeight - resultingY;
                adjustedY = true;
            }

            PositionCrosshairs(leftoverX, leftoverY);
        }

        public void PositionCrosshairs(double leftoverX, double leftoverY)
        {
            // we need to have read the SVG file to get its crosshair locations
            if(!string.IsNullOrEmpty(vertA) && !string.IsNullOrEmpty(horzA)
                && !string.IsNullOrEmpty(vertB) && !string.IsNullOrEmpty(horzA))
            {
                // GIMP (and I think Photoshop) center the image upon import, so whichever dimension was reduced
                // to below the map size has some "leftover" space. This math expects the image
                // to be placed such that the "empty leftover" space is evenly split between
                // the map edges, i.e. centered.

                // either X coord of the vertical line is the centerpoint of the horizontal line
                // so we take that X, subtract the "X left margin", multiply by the scaling factor and split the leftover space
                crosshairAX = ((ExtractX1(vertA) - ExtractX1(horzA)) * svgFactor + Math.Truncate(leftoverX / 2));
                // either Y coord of the horizontal line is the centerpoint of the vertical line
                // so we take that Y, subtract the "Y top margin", multiply by the scaling factor and split the leftover space
                crosshairAY = ((ExtractY1(horzA) - ExtractY1(vertA)) * svgFactor + Math.Truncate(leftoverY / 2));

                // either X coord of the vertical line is the centerpoint of the horizontal line
                // so we take that X, subtract the "X left margin", multiply by the scaling factor and split the leftover space
                crosshairBX = ((ExtractX1(vertB) - ExtractX1(horzA)) * svgFactor + Math.Truncate(leftoverX / 2));
                // either Y coord of the horizontal line is the centerpoint of the vertical line
                // so we take that Y, subtract the "Y top margin", multiply by the scaling factor and split the leftover space
                crosshairBY = ((ExtractY1(horzB) - ExtractY1(vertA)) * svgFactor + Math.Truncate(leftoverY / 2));
            }
        }

        public void CalcZoneRect()
        {
            // zonerect
            double svgWidth = LRX - ULX;
            double svgHeight = LRY - ULY;
            double crosshairWidth = crosshairBX - crosshairAX;
            double crosshairHeight = crosshairBY - crosshairAY;
            wdppx = svgWidth / crosshairWidth;
            wdppy = svgHeight / crosshairHeight;
            Debug.WriteLine($"wdppx={wdppx} wdppy={wdppy}");
            LOC0x = (ULX - wdppx * (crosshairAX - 0)) * -1;
            LOC1x = (wdppx * (imageWidth - crosshairBX) + LRX) * -1;
            LOC0y = ULY - wdppy * (crosshairAY - 0);
            LOC1y = wdppy * (imageHeight - crosshairBY) + LRY;
            zonerect = $"zonerect=\"{LOC0x:N0}, {LOC0y:N0}, {LOC1x:N0}, {LOC1y:N0}\"";
            Debug.WriteLine($"{zonerect}");
        }

        public void FixAspectForNewX()
        {
            svgFactor = inputScaleWidth / svgXextent;
            inputScaleHeight = svgFactor * svgYextent;
            Debug.WriteLine($"New ratio:{svgFactor}; New Y for entered X:{inputScaleHeight}");
            PositionCrosshairs(imageWidth - inputScaleWidth, imageHeight - inputScaleHeight);
            CalcZoneRect();
        }

        public void FixAspectForNewY()
        {
            svgFactor = inputScaleHeight / svgYextent;
            inputScaleWidth = svgFactor * svgXextent;
            Debug.WriteLine($"New ratio:{svgFactor}; New X for entered Y:{inputScaleWidth}");
            PositionCrosshairs(imageWidth - inputScaleWidth, imageHeight - inputScaleHeight);
            CalcZoneRect();
        }

        double ExtractX1(string? svg)
        {
            if (svg != null)
            {
                Match match = reNewLine.Match(svg);
                if (match.Success)
                    return double.Parse(match.Groups["x1"].Value);
                else if ((match = reNewLineInk.Match(svg)).Success)
                    return double.Parse(match.Groups["x1"].Value);
            }
            return double.NaN;
        }

        double ExtractX2(string? svg)
        {
            if (svg != null)
            {
                Match match = reNewLine.Match(svg);
                if (match.Success)
                    return double.Parse(match.Groups["x2"].Value);
                else if ((match = reNewLineInk.Match(svg)).Success)
                {
                    // inkscape
                    if (match.Groups["dir"].Value.ToLower() == "v")
                        return ExtractX1(svg);
                    else if (match.Groups["dir"].Value == "H")
                        return double.Parse(match.Groups["dest"].Value);
                    else if (match.Groups["dir"].Value == "h")
                        return ExtractX1(svg) + double.Parse(match.Groups["dest"].Value);
                }
            }
            return double.NaN;
        }

        double ExtractY1(string? svg)
        {
            if (svg != null)
            {
                Match match = reNewLine.Match(svg);
                if (match.Success)
                    return double.Parse(match.Groups["y1"].Value);
                else if ((match = reNewLineInk.Match(svg)).Success)
                    return double.Parse(match.Groups["y1"].Value);
            }
            return double.NaN;
        }

        double ExtractY2(string? svg)
        {
            if (svg != null)
            {
                Match match = reNewLine.Match(svg);
                if (match.Success)
                    return double.Parse(match.Groups["y2"].Value);
                else if ((match = reNewLineInk.Match(svg)).Success)
                {
                    // inkscape
                    if (match.Groups["dir"].Value.ToLower() == "h")
                        return ExtractY1(svg);
                    else if (match.Groups["dir"].Value == "V")
                        return double.Parse(match.Groups["dest"].Value);
                    else if (match.Groups["dir"].Value == "v")
                        return ExtractY1(svg) + double.Parse(match.Groups["dest"].Value);
                }
            }
            return double.NaN;
        }
    }

}
