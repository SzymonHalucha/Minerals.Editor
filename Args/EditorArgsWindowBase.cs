namespace Minerals.Editor.Args
{
    public abstract class EditorArgsWindowBase(IEditorWindow window) : IEditorArgs
    {
        public IEditorWindow Window { get; init; } = window;
    }
}