namespace Minerals.Editor.StateMachine.Transitions
{
    public class EditorTransitionOnMouseLeave<T1, T2> : EditorTransitionMouseEventBase<T1, T2, EditorEventOnMouseLeave>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new()
    {

    }
}