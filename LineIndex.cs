namespace EQ2MapTools
{
    // for binding to the datagridview
    public class LineIndex : List<SvgLine>
    {
        public string fileName = string.Empty;
    }

    public class SvgLine
    {
        public string svgId { get; set; } = string.Empty;
        public long lineNumber { get; set; }
    }
}
