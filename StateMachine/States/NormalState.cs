namespace Minerals.Editor.StateMachine.States
{
    public class NormalState : StateMachineBase, IEditorState
    {
        public IEditorState OnEnter(IEditorArgs[]? args = null) => this;
        public IEditorState OnExit(IEditorArgs[]? args = null) => this;
    }
}