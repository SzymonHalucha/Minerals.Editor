namespace Minerals.Editor.StateMachine
{
    public interface IEditorStateMachine
    {
        public IEditorStateMachine OnSetup(IEditorWindow target, IEditorArgs[]? args = null);
        public IEditorStateMachine OnDestroy();
        public IEditorWindow GetWindow();
    }
}