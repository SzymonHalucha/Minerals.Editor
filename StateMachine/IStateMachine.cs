namespace Minerals.Editor.StateMachine
{
    public interface IStateMachine
    {
        public IStateMachine OnSetup(IEditorWindow target, IEditorArgs[]? args = null);
        public IStateMachine OnDestroy();
        public IEditorWindow GetWindow();
    }
}