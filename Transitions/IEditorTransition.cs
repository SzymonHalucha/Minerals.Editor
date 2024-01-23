namespace Minerals.Editor.Transitions
{
    public interface IEditorTransition
    {
        public IEditorTransition OnSetup
        (
            IEditorWindow target,
            IEditorArgs[]? transitionArgs = null,
            IEditorArgs[]? exitStateArgs = null,
            IEditorArgs[]? enterStateArgs = null
        );

        public IEditorTransition OnDestroy(IEditorArgs[]? args = null);
        public IEditorWindow GetWindow();
    }

    public interface IEditorTransition<T1, T2> : IEditorTransition
        where T1 : IEditorState, new()
        where T2 : IEditorState, new()
    { }
}