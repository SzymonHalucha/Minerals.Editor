namespace Minerals.Editor.Components
{
    public interface IEditorComponent
    {
        public IEditorComponent? ParentInherited { get; set; }
        public IEditorThemes? ThemesInherited { get; set; }

        public IEditorComponent? Parent { get; set; }
        public IEditorThemes? Themes { get; set; }
        public RenderFragment? ChildContent { get; set; }

        public string? Id { get; set; }
        public string? Title { get; set; }

        public string? Tag { get; set; }
        public string? Class { get; set; }

        public bool IsThemable { get; set; }

        public Anchor? Anchor { get; set; }
        public Unit? Left { get; set; }
        public Unit? Right { get; set; }
        public Unit? Top { get; set; }
        public Unit? Bottom { get; set; }
        public Unit? Width { get; set; }
        public Unit? Height { get; set; }

        public IEditorWindow? Window { get; }
    }
}