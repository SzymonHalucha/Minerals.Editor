namespace Minerals.Editor.StateMachine.Transitions
{
    public class EditorTransitionOnMouseUp<T1, T2> : EditorTransitionMouseEventBase<T1, T2, EditorEventOnMouseUp>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new()
    {

    }
}