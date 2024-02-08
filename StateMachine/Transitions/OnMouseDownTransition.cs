namespace Minerals.Editor.StateMachine.Transitions
{
    public class OnMouseDownTransition<T1, T2> : MouseEventBaseTransition<T1, T2, EditorEventOnMouseDown>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new();
}