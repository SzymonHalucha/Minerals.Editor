namespace Minerals.Editor.Features
{
    public abstract class EditorFeatureBase : IEditorFeature
    {
        public IEditorWindow? Root { get; protected set; }

        public void OnSetup(IEditorWindow root)
        {
            Root = root;
        }

        public virtual void AppendAttributes(int sequence, RenderTreeBuilder builder)
        {

        }

        public virtual void AppendContent(RenderTreeBuilder builder)
        {

        }
    }
}