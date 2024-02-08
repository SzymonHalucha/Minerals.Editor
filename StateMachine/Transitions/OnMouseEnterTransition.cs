namespace Minerals.Editor.StateMachine.Transitions
{
    public class OnMouseEnterTransition<T1, T2> : MouseEventBaseTransition<T1, T2, EditorEventOnMouseEnter>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new();
}