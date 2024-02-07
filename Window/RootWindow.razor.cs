namespace Minerals.Editor.Window
{
    public partial class RootWindow : WindowComponentBase
    {
        protected override void OnWindowBuild()
        {
            var builder = new EditorWindowBuilder()
                .BuildForReference(Window!)
                .SetId(Id)
                .SetTag(Tag)
                .SetTransform(new()
                {
                    Anchor = Anchor ?? AllAnchor.Default,
                    Left = Left ?? new PixelUnit(0),
                    Right = Right ?? new PixelUnit(0),
                    Top = Top ?? new PixelUnit(0),
                    Bottom = Bottom ?? new PixelUnit(0),
                    Width = Width ?? new PixelUnit(0),
                    Height = Height ?? new PixelUnit(0)
                })
                .AddComponent<EditorComponentStyles>(out _)
                .AddComponent<EditorComponentEvents>(out _)
                .AddComponent<EditorComponentStates>(out _)
                .AddComponent<EditorComponentThemes>(out _)
                .AddClasses(ThemeComponents.RootWindow)
                .AddClasses(Class)
                .AddDefaultStyle()
                .AddDefaultState();

            if (IsThemable)
            {
                builder.AddComponent<EditorComponentThemes>(out _);
                builder.SetEditorThemes(Themes ?? ThemesInherited);
            }

            builder.Build();
        }
    }
}