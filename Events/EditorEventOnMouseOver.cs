namespace Minerals.Editor.Events
{
    public class EditorEventOnMouseOver : EditorEventBase<MouseEventArgs>
    {
        public override string Name { get; } = "onmouseover";
    }
}