namespace Minerals.Editor.Components
{
    public abstract class EditorComponentBase : IEditorComponent
    {
        public IEditorWindow? Root { get; protected set; }

        public void SetupComponent(IEditorWindow root)
        {
            Root ??= root;
        }

        public virtual void AppendAttributes(int sequence, RenderTreeBuilder builder)
        {

        }

        public virtual void AppendContent(RenderTreeBuilder builder)
        {

        }
    }
}