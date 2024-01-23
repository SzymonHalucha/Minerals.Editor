namespace Minerals.Editor.Events
{
    public class EditorEventOnMouseDown : EditorEventBase<MouseEventArgs>
    {
        public override string Name { get; } = "onmousedown";
    }
}