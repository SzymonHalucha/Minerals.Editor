namespace Minerals.Editor.StateMachine.Transitions
{
    public class OnMouseLeaveTransition<T1, T2> : MouseEventBaseTransition<T1, T2, EditorEventOnMouseLeave>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new();
}