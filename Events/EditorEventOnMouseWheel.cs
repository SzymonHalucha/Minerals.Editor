namespace Minerals.Editor.Events
{
    public class EditorEventOnMouseWheel : EditorEventBase<WheelEventArgs>
    {
        public override string Name { get; } = "onwheel";
    }
}