namespace Minerals.Editor.Themes
{
    public record Theme(string Id, string Name, string Author)
    {
        public static Theme Default { get; } = new("dark", "Dark", "Szymon Halucha");
    }
}