namespace Minerals.Editor.Themes
{
    public interface IEditorThemes
    {
        public Theme CurrentTheme { get; }
        public string CurrentFilename { get; }

        public event Action<Theme>? ThemeChanged;

        public void SetCurrentTheme(Theme theme);
        public void LoadAvailableThemes(Func<Theme[]> loader);
        public Theme[] GetAvailableThemes();
        public void LoadInstalledThemes(Func<Theme[]> loader);
        public Theme[] GetInstalledThemes();
    }
}