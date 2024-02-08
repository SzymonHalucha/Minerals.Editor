namespace Minerals.Editor.StateMachine.Transitions
{
    public class OnMouseOutTransition<T1, T2> : MouseEventBaseTransition<T1, T2, EditorEventOnMouseOut>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new();
}