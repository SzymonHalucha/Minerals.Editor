namespace Minerals.Editor.Window
{
    public partial class DefaultWindow : WindowComponentBase
    {
        [Parameter] public bool IsMovable { get; set; } = true;
        [Parameter] public bool IsClosable { get; set; } = true;
        [Parameter] public bool IsResizable { get; set; } = true;
        [Parameter] public bool IsVerticalResizable { get; set; } = true;
        [Parameter] public bool IsHorizontalResizable { get; set; } = true;
        [Parameter] public bool IsSnappable { get; set; }
        [Parameter] public bool IsScrollable { get; set; }

        protected override void OnWindowBuild()
        {
            var builder = new EditorWindowBuilder()
                .BuildForReference(Window!)
                .SetId(Id)
                .SetTag(Tag)
                .SetParent(Parent!.Window)
                .SetTransform(new()
                {
                    Anchor = Anchor ?? TopLeftAnchor.Default,
                    Left = Left ?? new PixelUnit(0),
                    Right = Right ?? new PixelUnit(0),
                    Top = Top ?? new PixelUnit(0),
                    Bottom = Bottom ?? new PixelUnit(0),
                    Width = Width ?? new PixelUnit(200),
                    Height = Height ?? new PixelUnit(200)
                })
                .AddComponent<EditorComponentStyles>(out _)
                .AddComponent<EditorComponentEvents>(out _)
                .AddComponent<EditorComponentStates>(out _)
                .AddClasses(ThemeComponents.DefaultWindow)
                .AddClasses(Class)
                .AddDefaultStyle()
                .AddDefaultState();

            if (IsThemable)
            {
                builder.AddComponent<EditorComponentThemes>(out _);
                builder.SetEditorThemes(Themes ?? ThemesInherited);
            }

            if (IsMovable)
            {
                EditorWindow cmp = EditorWindowBuilder.BuildHeaderWindow(Window);
                builder.AddMovableFeature(cmp);
            }

            if (IsClosable)
            {
                EditorWindow cmp = EditorWindowBuilder.BuildCloseWindow(Window);
                builder.AddClosableFeature(cmp);
            }

            if (IsResizable)
            {
                EditorWindow cmp = EditorWindowBuilder.BuildResizeWindow(Window);
                builder.AddResizableFeature(cmp);
            }

            if (IsVerticalResizable)
            {
                EditorWindow cmp = EditorWindowBuilder.BuildVerticalResizeWindow(Window);
                builder.AddVerticalResizableFeature(cmp);
            }

            if (IsHorizontalResizable)
            {
                EditorWindow cmp = EditorWindowBuilder.BuildHorizontalResizeWindow(Window);
                builder.AddHorizontalResizableFeature(cmp);
            }

            if (IsSnappable)
            {
                builder.AddSnappableFeature();
            }

            if (IsScrollable)
            {
                builder.AddScrollableFeature();
            }

            builder.Build();
        }
    }
}