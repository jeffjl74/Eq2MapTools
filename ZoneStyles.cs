
using System.Runtime.CompilerServices;

namespace EQ2MapTools
{
    public class ZoneStyles : List<ZoneStyle>
    {
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
            return StyleName == null ? string.Empty : StyleName;
        }

    }
}
