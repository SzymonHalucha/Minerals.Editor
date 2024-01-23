namespace Minerals.Editor.States
{
    public interface IEditorState
    {
        public IEditorState OnSetup(IEditorWindow target, IEditorArgs[]? args = null);
        public IEditorState OnEnter(IEditorArgs[]? args = null);
        public IEditorState OnExit(IEditorArgs[]? args = null);
        public IEditorState OnDestroy(IEditorArgs[]? args = null);
        public IEditorWindow GetWindow();
    }
}