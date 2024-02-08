namespace Minerals.Editor.Builders
{
    public interface IEditorWindowBuilder
    {
        public IEditorWindowBuilder CreateNew();
        public IEditorWindowBuilder BuildForReference(IEditorWindow target);
        public IEditorWindowBuilder AddFeature<T>(out T feature) where T : class, IEditorFeature, new();
        public IEditorWindowBuilder AddDefaultStyle();
        public IEditorWindowBuilder AddDefaultState();
        public IEditorWindowBuilder AddMoveState(IEditorWindow moveComponent);
        public IEditorWindowBuilder AddCloseState(IEditorWindow closeComponent);
        public IEditorWindowBuilder AddResizeState(IEditorWindow resizeComponent);
        public IEditorWindowBuilder AddVerticalResizeState(IEditorWindow verticalResizeComponent);
        public IEditorWindowBuilder AddHorizontalResizeState(IEditorWindow horizontalResizeComponent);
        public IEditorWindowBuilder AddSnapState();
        public IEditorWindowBuilder AddScrollState();
        public IEditorWindowBuilder AddClasses(string? classes);
        public IEditorWindowBuilder SetTransform(Transform? transform);
        public IEditorWindowBuilder SetParent(IEditorWindow? parent);
        public IEditorWindowBuilder SetEditorThemes(IEditorThemes? themes);
        public IEditorWindowBuilder SetTag(string? tag);
        public IEditorWindowBuilder SetId(string? id);
        public EditorWindow Build();
    }
}