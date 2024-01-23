namespace Minerals.Editor.Events
{
    public class EditorEventOnMouseOut : EditorEventBase<MouseEventArgs>
    {
        public override string Name { get; } = "onmouseout";
    }
}