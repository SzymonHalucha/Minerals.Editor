namespace Minerals.Editor.StateMachine.States
{
    public abstract class EditorStateMouseEventBase<T> : EditorStateMachineBase, IEditorState
        where T : IEditorEvent<MouseEventArgs>, new()
    {
        protected IEditorWindow? Source;
        protected EditorPoint Position;
        protected EditorPoint Size;

        public override IEditorState OnSetup(IEditorWindow target, IEditorArgs[]? args = null)
        {
            base.OnSetup(target, args);
            Source = GetEditorArgs<EditorArgsEventSource>(args)!.Source;
            return this;
        }

        public virtual IEditorState OnEnter(IEditorArgs[]? args = null)
        {
            Size = Target!.Transform.Size;
            Position = Target.Transform.Position;
            Source!.GetComponent<EditorComponentEvents>()!.SubscribeEvent<T, MouseEventArgs>(DoAction);
            Source.Refresh();
            return this;
        }

        public virtual IEditorState OnExit(IEditorArgs[]? args = null)
        {
            Source!.GetComponent<EditorComponentEvents>()!.UnsubscribeEvent<T, MouseEventArgs>(DoAction);
            Source.Refresh();

            if (!HasEditorArgs<EditorArgsSaveTransform>(args))
            {
                Target!.Transform.Position = Position;
                Target.Transform.Size = Size;
            }

            return this;
        }

        protected abstract void DoAction(MouseEventArgs args);
    }
}