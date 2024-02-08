namespace Minerals.Editor.Builders
{
    public class EditorWindowDirector : IEditorWindowDirector
    {
        public EditorWindow BuildHeaderWindow(IEditorWindow? parent)
        {
            Transform transform = new()
            {
                Anchor = HorizontalTopAnchor.Default,
                Height = new PixelUnit(32)
            };
            return CreateEventBaseWindow
            (
                transform,
                parent,
                ThemeSelectors.EditorHeader
            ).Build();
        }

        public EditorWindow BuildCloseWindow(IEditorWindow? parent)
        {
            Transform transform = new()
            {
                Anchor = TopRightAnchor.Default,
                Width = new PixelUnit(32),
                Height = new PixelUnit(32)
            };
            return CreateEventBaseWindow
            (
                transform,
                parent,
                ThemeSelectors.EditorClose
            ).Build();
        }

        public EditorWindow BuildResizeWindow(IEditorWindow? parent)
        {
            Transform transform = new()
            {
                Anchor = BottomRightAnchor.Default,
                Width = new PixelUnit(16),
                Height = new PixelUnit(16)
            };
            return CreateEventBaseWindow
            (
                transform,
                parent,
                ThemeSelectors.EditorResize
            ).Build();
        }

        public EditorWindow BuildVerticalResizeWindow(IEditorWindow? parent)
        {
            Transform transform = new()
            {
                Anchor = HorizontalBottomAnchor.Default,
                Right = new PixelUnit(16),
                Height = new PixelUnit(16)
            };
            return CreateEventBaseWindow
            (
                transform,
                parent,
                ThemeSelectors.EditorVerticalResize
            ).Build();
        }

        public EditorWindow BuildHorizontalResizeWindow(IEditorWindow? parent)
        {
            Transform transform = new()
            {
                Anchor = VerticalRightAnchor.Default,
                Top = new PixelUnit(32),
                Bottom = new PixelUnit(16),
                Width = new PixelUnit(16)
            };
            return CreateEventBaseWindow
            (
                transform,
                parent,
                ThemeSelectors.EditorHorizontalResize
            ).Build();
        }

        private static EditorWindowBuilder CreateEventBaseWindow
        (
            Transform transform,
            IEditorWindow? parent = null,
            string? classes = null
        )
        {
            return (EditorWindowBuilder)new EditorWindowBuilder()
                .CreateNew()
                .SetParent(parent)
                .SetTransform(transform)
                .AddFeature<EditorFeatureEvents>(out _)
                .AddFeature<EditorFeatureStyles>(out _)
                .AddFeature<EditorFeatureThemes>(out _)
                .SetEditorThemes(parent!.GetFeature<EditorFeatureThemes>()?.EditorThemes)
                .AddClasses(classes)
                .AddDefaultStyle();
        }
    }
}