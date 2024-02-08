namespace Minerals.Editor.StateMachine.States
{
    public class VerticalResizeState : MouseEventBaseState<EditorEventOnMouseMove>
    {
        protected override void DoAction(MouseEventArgs args)
        {
            Target!.Anchor!.AddDeltaSize(0, args.MovementY);
            Target.Parent!.Refresh();
        }
    }
}