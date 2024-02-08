namespace Minerals.Editor.StateMachine.Transitions
{
    public class OnMouseUpTransition<T1, T2> : MouseEventBaseTransition<T1, T2, EditorEventOnMouseUp>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new();
}