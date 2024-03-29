namespace Minerals.Editor.StateMachine.States
{
    public class CloseState : StateMachineBase, IEditorState
    {
        public IEditorState OnEnter(IEditorArgs[]? args = null)
        {
            Target!.Enable = false;
            return this;
        }

        public IEditorState OnExit(IEditorArgs[]? args = null)
        {
            Target!.Enable = true;
            return this;
        }
    }
}