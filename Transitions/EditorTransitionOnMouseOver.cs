namespace Minerals.Editor.Transitions
{
    public class EditorTransitionOnMouseOver<T1, T2> : EditorTransitionMouseEventBase<T1, T2, EditorEventOnMouseOver>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new()
    {

    }
}