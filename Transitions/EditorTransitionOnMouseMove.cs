namespace Minerals.Editor.Transitions
{
    public class EditorTransitionOnMouseMove<T1, T2> : EditorTransitionMouseEventBase<T1, T2, EditorEventOnMouseMove>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new()
    {

    }
}