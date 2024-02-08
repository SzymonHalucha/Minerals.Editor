namespace Minerals.Editor.StateMachine.States
{
    public class HorizontalResizeState : MouseEventBaseState<EditorEventOnMouseMove>
    {
        protected override void DoAction(MouseEventArgs args)
        {
            Target!.Transform.TranslateSize(args.MovementX, 0);
            Target.Parent!.Refresh();
        }
    }
}