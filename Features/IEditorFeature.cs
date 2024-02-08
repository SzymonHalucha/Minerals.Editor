namespace Minerals.Editor.Features
{
    public interface IEditorFeature
    {
        public IEditorWindow? Root { get; }

        public void OnSetup(IEditorWindow root);
        public void AppendAttributes(int sequence, RenderTreeBuilder builder);
        public void AppendContent(RenderTreeBuilder builder);
    }
}