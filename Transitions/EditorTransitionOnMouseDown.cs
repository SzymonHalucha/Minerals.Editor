namespace Minerals.Editor.Transitions
{
    public class EditorTransitionOnMouseDown<T1, T2> : EditorTransitionMouseEventBase<T1, T2, EditorEventOnMouseDown>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new()
    {

    }
}