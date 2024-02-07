namespace Minerals.Editor.Window
{
    public interface IWindowComponent
    {
        public IWindowComponent? Parent { get; set; }
        public IEditorThemes? ThemesInherited { get; set; }
        public IEditorThemes? Themes { get; set; }
        public RenderFragment? ChildContent { get; set; }

        public string? Id { get; set; }
        public string? Title { get; set; }

        public string? Tag { get; set; }
        public string? Class { get; set; }

        public bool IsThemable { get; set; }

        public EditorAnchor? Anchor { get; set; }
        public EditorUnit? Left { get; set; }
        public EditorUnit? Right { get; set; }
        public EditorUnit? Top { get; set; }
        public EditorUnit? Bottom { get; set; }
        public EditorUnit? Width { get; set; }
        public EditorUnit? Height { get; set; }

        public IEditorWindow? Window { get; }
    }
}