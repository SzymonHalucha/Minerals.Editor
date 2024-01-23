
namespace Minerals.Editor.Themes
{
    public class EditorThemes : IEditorThemes
    {
        public Theme CurrentTheme { get; private set; } = Theme.Default;
        public string CurrentFilename => $"{CurrentTheme.Id}.css";

        public event Action<Theme>? ThemeChanged;

        private Theme[] _available = [];
        private Theme[] _installed = [];

        public void SetCurrentTheme(Theme theme)
        {
            CurrentTheme = theme;
            ThemeChanged?.Invoke(CurrentTheme);
        }

        public void LoadAvailableThemes(Func<Theme[]> loader)
        {
            _available = loader.Invoke();
        }

        public Theme[] GetAvailableThemes()
        {
            return _available;
        }

        public void LoadInstalledThemes(Func<Theme[]> loader)
        {
            _installed = loader.Invoke();
        }

        public Theme[] GetInstalledThemes()
        {
            return _installed;
        }
    }
}