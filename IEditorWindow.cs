namespace Minerals.Editor
{
    public interface IEditorWindow
    {
        public RenderFragment? ChildContent { get; set; }
        public string? Id { get; set; }
        public string Tag { get; set; }

        public EditorTransform Transform { get; set; }
        public IEditorWindow? Parent { get; set; }
        public bool Enable { get; set; }

        public IEditorWindow SetContent(RenderTreeBuilder builder);

        public IEditorWindow AddChild(IEditorWindow window);
        public IEditorWindow RemoveChild(IEditorWindow window);
        public bool HasChild(IEditorWindow window);

        public T? AddComponent<T>() where T : class, IEditorComponent, new();
        public T? RemoveComponent<T>() where T : class, IEditorComponent, new();
        public T? GetComponent<T>() where T : class, IEditorComponent, new();
        public T AddOrGetComponent<T>() where T : class, IEditorComponent, new();
        public bool HasComponent<T>() where T : class, IEditorComponent, new();

        public IEditorWindow Refresh();
    }
}