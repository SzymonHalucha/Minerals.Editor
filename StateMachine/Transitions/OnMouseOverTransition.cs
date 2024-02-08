namespace Minerals.Editor.StateMachine.Transitions
{
    public class OnMouseOverTransition<T1, T2> : MouseEventBaseTransition<T1, T2, EditorEventOnMouseOver>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new();
}