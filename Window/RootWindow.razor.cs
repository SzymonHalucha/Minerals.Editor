namespace Minerals.Editor.Window
{
    public partial class RootWindow : WindowComponentBase
    {
        [Parameter] public IEditorThemes? Themes { get; set; }
        [Parameter] public string? ThemesIndex { get; set; }
        [Parameter] public string? DefaultTheme { get; set; }
        [Parameter] public bool IsThemable { get; set; } = false;

        protected override void OnWindowBuild()
        {
            var builder = new EditorWindowBuilder()
                .BuildForReference(Window!)
                .SetId(Id)
                .SetTag(Tag)
                .SetTransform(new(Size, Position))
                .AddComponent<EditorComponentStyles>(out _)
                .AddComponent<EditorComponentEvents>(out _)
                .AddComponent<EditorComponentStates>(out _)
                .AddComponent<EditorComponentThemes>(out _)
                .AddClasses(ThemeComponents.RootWindow)
                .AddClasses(Class)
                .AddDefaultStyle()
                .AddDefaultState()
                .Build();

            if (IsThemable)
            {
                InvokeAsync(SetThemesManagerAsync);
            }
        }

        private async Task SetThemesManagerAsync()
        {
            await Themes!.LoadAvailableThemesAsync(ThemesIndex!);
            var theme = Themes.Available.FirstOrDefault(x => x.Id == DefaultTheme);
            Window!.GetComponent<EditorComponentThemes>()!.SetThemes(Themes);
            Themes.ThemeChanged += OnThemeChanged;
            Themes.SetActive(theme ?? ThemePackage.Empty);
        }

        private void OnThemeChanged(ThemePackage oldTheme, ThemePackage newTheme)
        {
            InvokeAsync(StateHasChanged);
        }
    }
}