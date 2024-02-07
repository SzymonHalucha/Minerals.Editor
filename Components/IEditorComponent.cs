namespace Minerals.Editor.Components
{
    public interface IEditorComponent
    {
        public IEditorWindow? Root { get; }

        public void SetupComponent(IEditorWindow root);
        public void AppendAttributes(int sequence, RenderTreeBuilder builder);
        public void AppendContent(RenderTreeBuilder builder);
    }
}