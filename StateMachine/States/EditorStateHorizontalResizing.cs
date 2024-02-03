namespace Minerals.Editor.StateMachine.States
{
    public class EditorStateHorizontalResizing : EditorStateMouseEventBase<EditorEventOnMouseMove>
    {
        protected override void DoAction(MouseEventArgs args)
        {
            var old = Target!.Transform.Size;
            Target.Transform.Size = new(old.Width + args.MovementX, old.Height);
            Target.Parent!.Refresh();
        }
    }
}