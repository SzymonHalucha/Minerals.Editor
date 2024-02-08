namespace Minerals.Editor
{
    public interface IEditorWindow
    {
        public RenderFragment? ChildContent { get; set; }
        public string? Id { get; set; }
        public string Tag { get; set; }

        public IEditorAnchor? Anchor { get; set; }
        public IEditorWindow? Parent { get; set; }
        public bool Enable { get; set; }

        public IEditorWindow SetContent(RenderTreeBuilder builder);

        public IEditorWindow AddChild(IEditorWindow window);
        public IEditorWindow RemoveChild(IEditorWindow window);
        public bool HasChild(IEditorWindow window);

        public T? AddFeature<T>() where T : class, IEditorFeature, new();
        public T? RemoveFeature<T>() where T : class, IEditorFeature, new();
        public T? GetFeature<T>() where T : class, IEditorFeature, new();
        public T AddOrGetFeature<T>() where T : class, IEditorFeature, new();
        public bool HasFeature<T>() where T : class, IEditorFeature, new();

        public IEditorWindow Refresh();
    }
}