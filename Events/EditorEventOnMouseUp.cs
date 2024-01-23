namespace Minerals.Editor.Events
{
    public class EditorEventOnMouseUp : EditorEventBase<MouseEventArgs>
    {
        public override string Name { get; } = "onmouseup";
    }
}