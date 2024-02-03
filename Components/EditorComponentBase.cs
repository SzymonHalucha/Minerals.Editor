namespace Minerals.Editor.Components
{
    public abstract class EditorComponentBase : IEditorComponent
    {
        public IEditorWindow? Root { get; protected set; }

        public void OnSetup(IEditorWindow root)
        {
            Root ??= root;
        }

        public virtual void SetAttributes(int sequence, RenderTreeBuilder builder)
        {

        }

        public virtual void SetContent(RenderTreeBuilder builder)
        {

        }
    }
}