namespace Minerals.Editor.Themes
{
    public interface IEditorThemes
    {
        public ThemePackage Active { get; }
        public ThemePackage[] Available { get; }
        public ThemePackage[] Installed { get; }

        public event Action<ThemePackage, ThemePackage>? ThemeChanged;

        public Task<ThemePackage[]> LoadAvailableThemesAsync(string indexUrl);
        public Task<ThemePackage[]> LoadInstalledThemesAsync(string indexUrl);

        public void SetActive(ThemePackage theme);
        public string GetStyleUrl(ThemePackage theme);
    }
}