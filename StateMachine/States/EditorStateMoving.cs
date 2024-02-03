namespace Minerals.Editor.StateMachine.States
{
    public class EditorStateMoving : EditorStateMouseEventBase<EditorEventOnMouseMove>
    {
        public override IEditorState OnEnter(IEditorArgs[]? args = null)
        {
            base.OnEnter(args);
            if (HasEditorArgs<EditorArgsIgnoreEvents>(args))
            {
                Target!.GetComponent<EditorComponentStyles>()!.AddStyle("pointer-events", "none");
            }
            return this;
        }

        public override IEditorState OnExit(IEditorArgs[]? args = null)
        {
            base.OnExit(args);
            Target!.GetComponent<EditorComponentStyles>()!.AddStyle("pointer-events", "all");
            return this;
        }

        protected override void DoAction(MouseEventArgs args)
        {
            var old = Target!.Transform.Position;
            Target.Transform.Position = new(old.X + args.MovementX, old.Y + args.MovementY);
            Target.Parent!.Refresh();
        }
    }
}