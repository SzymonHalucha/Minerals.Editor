namespace Minerals.Editor.StateMachine.States
{
    public interface IEditorState : IEditorStateMachine
    {
        public IEditorState OnEnter(IEditorArgs[]? args = null);
        public IEditorState OnExit(IEditorArgs[]? args = null);
    }
}