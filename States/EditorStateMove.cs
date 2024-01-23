namespace Minerals.Editor.States
{
    public class EditorStateMove : EditorStateMouseEventBase<EditorEventOnMouseMove>
    {
        public override IEditorState OnEnter(IEditorArgs[]? args = null)
        {
            var ignoreArgs = args?.FirstOrDefault(x => x is EditorArgsIgnoreEvents);
            if (ignoreArgs is EditorArgsIgnoreEvents ignore && ignore.Value)
            {
                Target!.SetCssStyle("pointer-events", "none");
            }

            return base.OnEnter(args);
        }

        public override IEditorState OnExit(IEditorArgs[]? args = null)
        {
            Target!.SetCssStyle("pointer-events", "all");
            return base.OnExit(args);
        }

        protected override void DoActionOnMouseEvent(MouseEventArgs args)
        {
            var old = Target!.Position;
            Target.Position = new(old.X + args.MovementX, old.Y + args.MovementY);
            Target.Refresh();
        }
    }
}