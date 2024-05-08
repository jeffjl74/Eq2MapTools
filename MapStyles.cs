namespace EQ2MapTools
{
    public class MapStyles : List<StyleZoneRect>
    {

    }

    public class StyleZoneRect : IComparable<StyleZoneRect>, IEquatable<StyleZoneRect>
    {
        public string? DisplayName { get; set; } = string.Empty;
        public string? ZoneRect { get; set; } = string.Empty;
        public string? SourceRect { get; set; } = string.Empty;

        public int CompareTo(StyleZoneRect? other)
        {
            return this.ToString().CompareTo(other?.ToString());
        }

        public bool Equals(StyleZoneRect? other)
        {
            return this.ToString().Equals(other?.ToString());
        }

        public override string ToString()
        {
            return DisplayName == null ? string.Empty : DisplayName;
        }

    }
}
