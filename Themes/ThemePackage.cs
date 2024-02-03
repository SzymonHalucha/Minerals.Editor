namespace Minerals.Editor.Themes
{
    public record ThemePackage(string Id, string Name, string[] Authors, string Description, string DisplayVersion, int Version, string Url = "")
    {
        public static ThemePackage Empty { get; } = new ThemePackage
        (
            string.Empty,
            string.Empty,
            [],
            string.Empty,
            string.Empty,
            0
        );
    }
}