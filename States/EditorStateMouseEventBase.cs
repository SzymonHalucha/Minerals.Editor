namespace Minerals.Editor.States
{
    public abstract class EditorStateMouseEventBase<T> : IEditorState
        where T : IEditorEvent<MouseEventArgs>, new()
    {
        protected IEditorWindow? Target;
        protected IEditorWindow? Source;
        protected Point2D Position;
        protected Point2D Size;

        public virtual IEditorState OnSetup(IEditorWindow target, IEditorArgs[]? args = null)
        {
            Target = target;
            var sourceArgs = args?.FirstOrDefault(x => x is EditorArgsEventSource);
            Source = (sourceArgs as EditorArgsEventSource)!.Window;
            return this;
        }

        public virtual IEditorState OnEnter(IEditorArgs[]? args = null)
        {
            Size = Target!.Size;
            Position = Target.Position;
            Source!.SubscribeMouseEvent<T>(DoActionOnMouseEvent);
            Source.Refresh();
            Target.Refresh();
            return this;
        }

        public virtual IEditorState OnExit(IEditorArgs[]? args = null)
        {
            Source!.UnsubscribeMouseEvent<T>(DoActionOnMouseEvent);
            Source.Refresh();

            var saveArgs = args?.FirstOrDefault(x => x is EditorArgsSaveTransform);
            if (saveArgs is not EditorArgsSaveTransform save || !save.Value)
            {
                Target!.Position = Position;
                Target.Size = Size;
            }

            Target!.Refresh();
            return this;
        }

        public virtual IEditorState OnDestroy(IEditorArgs[]? args = null)
        {
            return this;
        }

        public virtual IEditorWindow GetWindow()
        {
            return Target!;
        }

        protected abstract void DoActionOnMouseEvent(MouseEventArgs args);
    }
}