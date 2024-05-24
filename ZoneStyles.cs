using System.Text.RegularExpressions;

namespace EQ2MapTools
{
    public class ZoneStyles : List<ZoneStyle>
    {
        static Regex reStyleZone = new Regex(@"(?<style>[^-]+)(?: - \((?<zone>.+)\))?$", RegexOptions.Compiled);

        public ZoneStyle? this[string s]
        {
            get
            {
                foreach(ZoneStyle zs in this)
                {
                    if(zs.StyleName == s)
                        return zs;
                }
                return null;
            }
        }

        public static string ParseStyleName(string s)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(s))
            {
                Match match = reStyleZone.Match(s);
                if (match.Success)
                    result = match.Groups["style"].Value.Trim();
            }
            return result;
        }

        public static string ParseZoneName(string s)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(s))
            {
                Match match = reStyleZone.Match(s);
                if (match.Success)
                    result = match.Groups["zone"].Value.Trim();
            }
            return result;
        }

        public bool StyleHasZone(string style, string zone)
        {
            bool result = false;
            foreach (ZoneStyle zs in this)
            {
                if (zs.StyleName == style && zs.ZoneName == zone)
                    return true;
            }
            return result;
        }
    }

    public class ZoneStyle : IComparable<ZoneStyle>, IEquatable<ZoneStyle>
    {
        public string? StyleName { get; set; } = string.Empty;
        public string? ZoneName { get; set; } = string.Empty;

        public int CompareTo(ZoneStyle? other)
        {
            return this.ToString().CompareTo(other?.ToString());
        }

        public bool Equals(ZoneStyle? other)
        {
            return this.ToString().Equals(other?.ToString());
        }

        public override string ToString()
        {
            if(string.IsNullOrEmpty(this.StyleName)) return string.Empty;
            if(string.IsNullOrEmpty(ZoneName)) return this.StyleName;
            // build a string that the regular expression will parse
            return $"{StyleName} - ({ZoneName})";
        }

    }
}
