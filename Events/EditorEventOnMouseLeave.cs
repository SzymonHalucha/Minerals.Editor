namespace Minerals.Editor.Events
{
    public class EditorEventOnMouseLeave : EditorEventBase<MouseEventArgs>
    {
        public override string Name { get; } = "onmouseleave";
    }
}