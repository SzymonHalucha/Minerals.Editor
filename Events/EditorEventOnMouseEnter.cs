namespace Minerals.Editor.Events
{
    public class EditorEventOnMouseEnter : EditorEventBase<MouseEventArgs>
    {
        public override string Name { get; } = "onmouseenter";
    }
}