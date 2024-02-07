namespace Minerals.Editor.StateMachine.States
{
    public class EditorStateResizing : EditorStateMouseEventBase<EditorEventOnMouseMove>
    {
        protected override void DoAction(MouseEventArgs args)
        {
            Target!.Transform.TranslateSize(args.MovementX, args.MovementY);
            Target.Parent!.Refresh();
        }
    }
}