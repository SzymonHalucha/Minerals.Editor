namespace Minerals.Editor.StateMachine.Transitions
{
    public class EditorTransitionOnMouseOut<T1, T2> : EditorTransitionMouseEventBase<T1, T2, EditorEventOnMouseOut>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new();
}