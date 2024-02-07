namespace Minerals.Editor.StateMachine.States
{
    public class EditorStateHorizontalResizing : EditorStateMouseEventBase<EditorEventOnMouseMove>
    {
        protected override void DoAction(MouseEventArgs args)
        {
            Target!.Transform.TranslateSize(args.MovementX, 0);
            Target.Parent!.Refresh();
        }
    }
}