namespace Minerals.Editor.StateMachine.Transitions
{
    public class OnMouseMoveTransition<T1, T2> : MouseEventBaseTransition<T1, T2, EditorEventOnMouseMove>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new();
}