namespace Minerals.Editor.Transitions
{
    public class EditorTransitionOnMouseEnter<T1, T2> : EditorTransitionMouseEventBase<T1, T2, EditorEventOnMouseEnter>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new()
    {

    }
}