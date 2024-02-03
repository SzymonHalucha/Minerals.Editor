namespace Minerals.Editor.StateMachine.Transitions
{
    public interface IEditorTransition : IEditorStateMachine
    {
        public IEditorTransition SetAdditionalArgs(IEditorArgs[]? exitStateArgs = null, IEditorArgs[]? enterStateArgs = null);
    }

    public interface IEditorTransition<T1, T2> : IEditorTransition
        where T1 : IEditorState, new()
        where T2 : IEditorState, new()
    { }
}