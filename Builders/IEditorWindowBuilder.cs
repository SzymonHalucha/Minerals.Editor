namespace Minerals.Editor.Builders
{
    public interface IEditorWindowBuilder
    {
        public IEditorWindowBuilder CreateNew();
        public IEditorWindowBuilder BuildForReference(IEditorWindow target);
        public IEditorWindowBuilder SetRoot(IEditorWindow root);
        public IEditorWindowBuilder SetParameters(string? tag = null, string? id = null, string? title = null);
        public IEditorWindowBuilder SetPositionAndSize(Point2D position, Point2D size);
        public IEditorWindowBuilder AddCloseFeature();
        public IEditorWindowBuilder AddSnapFeature(IEditorWindow[] snappers);
        public IEditorWindowBuilder AddMoveFeature();
        public IEditorWindowBuilder AddResizeFeature();
        public IEditorWindowBuilder AddResizeHorizontalFeature();
        public IEditorWindowBuilder AddResizeVerticalFeature();
        public IEditorWindow Build();
    }
}