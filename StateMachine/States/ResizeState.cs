namespace Minerals.Editor.StateMachine.States
{
    public class ResizeState : MouseEventBaseState<EditorEventOnMouseMove>
    {
        protected override void DoAction(MouseEventArgs args)
        {
            Target!.Anchor!.AddDeltaSize(args.MovementX, args.MovementY);
            Target.Parent!.Refresh();
        }
    }
}