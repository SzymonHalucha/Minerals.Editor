namespace Minerals.Editor.StateMachine.States
{
    public abstract class EditorStateMouseEventBase<T> : EditorStateMachineBase, IEditorState
        where T : IEditorEvent<MouseEventArgs>, new()
    {
        protected IEditorWindow? Source;
        protected EditorUnit? Left;
        protected EditorUnit? Right;
        protected EditorUnit? Top;
        protected EditorUnit? Bottom;
        protected EditorUnit? Width;
        protected EditorUnit? Height;

        public override IEditorState OnSetup(IEditorWindow target, IEditorArgs[]? args = null)
        {
            base.OnSetup(target, args);
            Source = GetEditorArgs<EditorArgsEventSource>(args)!.Source;
            return this;
        }

        public virtual IEditorState OnEnter(IEditorArgs[]? args = null)
        {
            Left = Target!.Transform.Left;
            Right = Target.Transform.Right;
            Top = Target.Transform.Top;
            Bottom = Target.Transform.Bottom;
            Width = Target.Transform.Width;
            Height = Target.Transform.Height;
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
                Target!.Transform.Left = Left!;
                Target.Transform.Right = Right!;
                Target.Transform.Top = Top!;
                Target.Transform.Bottom = Bottom!;
                Target.Transform.Width = Width!;
                Target.Transform.Height = Height!;
            }

            return this;
        }

        protected abstract void DoAction(MouseEventArgs args);
    }
}