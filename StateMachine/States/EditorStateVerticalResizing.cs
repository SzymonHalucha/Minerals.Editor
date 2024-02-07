namespace Minerals.Editor.StateMachine.States
{
    public class EditorStateVerticalResizing : EditorStateMouseEventBase<EditorEventOnMouseMove>
    {
        protected override void DoAction(MouseEventArgs args)
        {
            Target!.Transform.TranslateSize(0, args.MovementY);
            Target.Parent!.Refresh();
        }
    }
}