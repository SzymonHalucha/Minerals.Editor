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

        public IEditorAnchor? Anchor { get; set; }

        public IEditorWindow? Window { get; }
    }
}