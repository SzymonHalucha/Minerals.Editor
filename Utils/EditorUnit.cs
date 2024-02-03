namespace Minerals.Editor.Utils
{
    public enum EditorUnit
    {
        None,
        Pixel,
        Percent,
        VW,
        VH,
        VMin,
        VMax,
        Em,
        Rem
    }

    public static class EditorUnitHelper
    {
        public static string UnitToString(this EditorUnit unit) => unit switch
        {
            EditorUnit.Pixel => "px",
            EditorUnit.Percent => "%",
            EditorUnit.VW => "vw",
            EditorUnit.VH => "vh",
            EditorUnit.VMin => "vmin",
            EditorUnit.VMax => "vmax",
            EditorUnit.Em => "em",
            EditorUnit.Rem => "rem",
            _ => string.Empty
        };

        public static EditorUnit StringToUnit(this string unit) => unit switch
        {
            "px" => EditorUnit.Pixel,
            "%" => EditorUnit.Percent,
            "vw" => EditorUnit.VW,
            "vh" => EditorUnit.VH,
            "vmin" => EditorUnit.VMin,
            "vmax" => EditorUnit.VMax,
            "em" => EditorUnit.Em,
            "rem" => EditorUnit.Rem,
            _ => EditorUnit.None
        };
    }
}