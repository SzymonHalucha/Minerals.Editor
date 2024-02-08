namespace Minerals.Editor.Builders
{
    public class EditorWindowDirector : IEditorWindowDirector
    {
        public EditorWindow BuildHeaderWindow(IEditorWindow? parent)
        {
            var anchor = new HorizontalTopAnchor
            {
                Left = new PixelUnit(0),
                Right = new PixelUnit(32),
                Top = new PixelUnit(0),
                Height = new PixelUnit(32)
            };
            return CreateEventBaseWindow
            (
                anchor,
                parent,
                ThemeSelectors.EditorHeader
            ).Build();
        }

        public EditorWindow BuildCloseWindow(IEditorWindow? parent)
        {
            var anchor = new TopRightAnchor
            {
                Right = new PixelUnit(0),
                Top = new PixelUnit(0),
                Width = new PixelUnit(32),
                Height = new PixelUnit(32)
            };
            return CreateEventBaseWindow
            (
                anchor,
                parent,
                ThemeSelectors.EditorClose
            ).Build();
        }

        public EditorWindow BuildResizeWindow(IEditorWindow? parent)
        {
            var anchor = new BottomRightAnchor
            {
                Right = new PixelUnit(0),
                Bottom = new PixelUnit(0),
                Width = new PixelUnit(16),
                Height = new PixelUnit(16)
            };
            return CreateEventBaseWindow
            (
                anchor,
                parent,
                ThemeSelectors.EditorResize
            ).Build();
        }

        public EditorWindow BuildVerticalResizeWindow(IEditorWindow? parent)
        {
            var anchor = new HorizontalBottomAnchor
            {
                Left = new PixelUnit(0),
                Right = new PixelUnit(16),
                Bottom = new PixelUnit(0),
                Height = new PixelUnit(16)
            };
            return CreateEventBaseWindow
            (
                anchor,
                parent,
                ThemeSelectors.EditorVerticalResize
            ).Build();
        }

        public EditorWindow BuildHorizontalResizeWindow(IEditorWindow? parent)
        {
            var anchor = new VerticalRightAnchor
            {
                Right = new PixelUnit(0),
                Width = new PixelUnit(16),
                Top = new PixelUnit(32),
                Bottom = new PixelUnit(16)
            };
            return CreateEventBaseWindow
            (
                anchor,
                parent,
                ThemeSelectors.EditorHorizontalResize
            ).Build();
        }

        private static EditorWindowBuilder CreateEventBaseWindow
        (
            IEditorAnchor anchor,
            IEditorWindow? parent = null,
            string? classes = null
        )
        {
            return (EditorWindowBuilder)new EditorWindowBuilder()
                .CreateNew()
                .SetParent(parent)
                .SetAnchor(anchor)
                .AddFeature<EditorFeatureEvents>(out _)
                .AddFeature<EditorFeatureStyles>(out _)
                .AddFeature<EditorFeatureThemes>(out _)
                .SetEditorThemes(parent!.GetFeature<EditorFeatureThemes>()?.EditorThemes)
                .AddClasses(classes)
                .AddDefaultStyle();
        }
    }
}