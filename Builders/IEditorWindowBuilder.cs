namespace Minerals.Editor.Builders
{
    public interface IEditorWindowBuilder
    {
        public IEditorWindowBuilder CreateNew();
        public IEditorWindowBuilder BuildForReference(IEditorWindow target);
        public IEditorWindowBuilder AddComponent<T>(out T component) where T : class, IEditorComponent, new();
        public IEditorWindowBuilder AddDefaultStyle();
        public IEditorWindowBuilder AddDefaultState();
        public IEditorWindowBuilder AddMovableFeature(IEditorWindow moveComponent);
        public IEditorWindowBuilder AddClosableFeature(IEditorWindow closeComponent);
        public IEditorWindowBuilder AddResizableFeature(IEditorWindow resizeComponent);
        public IEditorWindowBuilder AddVerticalResizableFeature(IEditorWindow verticalResizeComponent);
        public IEditorWindowBuilder AddHorizontalResizableFeature(IEditorWindow horizontalResizeComponent);
        public IEditorWindowBuilder AddSnappableFeature();
        public IEditorWindowBuilder AddScrollableFeature();
        public IEditorWindowBuilder AddClasses(string? classes);
        public IEditorWindowBuilder SetTransform(EditorTransform? transform);
        public IEditorWindowBuilder SetParent(IEditorWindow? parent);
        public IEditorWindowBuilder SetEditorThemes(IEditorThemes? themes);
        public IEditorWindowBuilder SetTag(string? tag);
        public IEditorWindowBuilder SetId(string? id);
        public EditorWindow Build();
        public static abstract EditorWindow BuildHeaderWindow(IEditorWindow? parent);
        public static abstract EditorWindow BuildCloseWindow(IEditorWindow? parent);
        public static abstract EditorWindow BuildResizeWindow(IEditorWindow? parent);
        public static abstract EditorWindow BuildVerticalResizeWindow(IEditorWindow? parent);
        public static abstract EditorWindow BuildHorizontalResizeWindow(IEditorWindow? parent);
    }
}