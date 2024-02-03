namespace Minerals.Editor.StateMachine.States
{
    public class EditorStateResizing : EditorStateMouseEventBase<EditorEventOnMouseMove>
    {
        protected override void DoAction(MouseEventArgs args)
        {
            var old = Target!.Transform.Size;
            Target.Transform.Size = new(old.Width + args.MovementX, old.Height + args.MovementY);
            Target.Parent!.Refresh();
        }
    }
}