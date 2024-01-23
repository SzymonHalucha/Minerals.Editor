namespace Minerals.Editor.States
{
    public class EditorStateResizeHorizontal : EditorStateMouseEventBase<EditorEventOnMouseMove>
    {
        protected override void DoActionOnMouseEvent(MouseEventArgs args)
        {
            var old = Target!.Size;
            Target.Size = new(old.Width + args.MovementX, old.Height);
            Target.Refresh();
        }
    }
}