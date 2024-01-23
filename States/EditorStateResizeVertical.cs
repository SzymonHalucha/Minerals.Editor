namespace Minerals.Editor.States
{
    public class EditorStateResizeVertical : EditorStateMouseEventBase<EditorEventOnMouseMove>
    {
        protected override void DoActionOnMouseEvent(MouseEventArgs args)
        {
            var old = Target!.Size;
            Target.Size = new(old.Width, old.Height + args.MovementY);
            Target.Refresh();
        }
    }
}