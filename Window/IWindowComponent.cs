namespace Minerals.Editor.Window
{
    public interface IWindowComponent
    {
        public IWindowComponent? Parent { get; set; }
        public RenderFragment? ChildContent { get; set; }

        public string? Id { get; set; }
        public string? Title { get; set; }

        public string? Tag { get; set; }
        public string? Class { get; set; }

        public IEditorWindow? Window { get; }
    }
}