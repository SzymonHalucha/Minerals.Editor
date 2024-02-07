namespace Minerals.Editor.Anchors
{
    public record AllAnchor() : EditorAnchor("left:", "right:", "top:", "bottom:")
    {
        public static AllAnchor Default { get; } = new();

        public override void TranslatePosition(EditorTransform transform, double deltaX, double deltaY) { }

        public override void TranslateSize(EditorTransform transform, double deltaWidth, double deltaHeight) { }

        public override void Build(StringBuilder builder, EditorTransform transform)
        {
            AppendAllAnchors(builder, transform.Left, transform.Right, transform.Top, transform.Bottom);
        }
    }
}