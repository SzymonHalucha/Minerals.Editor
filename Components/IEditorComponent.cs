namespace Minerals.Editor.Components
{
    public interface IEditorComponent
    {
        public IEditorWindow? Root { get; }

        public void OnSetup(IEditorWindow root);
        public void SetAttributes(int sequence, RenderTreeBuilder builder);
        public void SetContent(RenderTreeBuilder builder);
    }
}