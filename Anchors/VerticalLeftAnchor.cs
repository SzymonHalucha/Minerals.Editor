namespace Minerals.Editor.Anchors
{
    public record VerticalLeftAnchor() : EditorAnchor("left:", "width:", "top:", "bottom:")
    {
        public static VerticalLeftAnchor Default { get; } = new();

        public override void TranslatePosition(EditorTransform transform, double deltaX, double deltaY)
        {
            transform.Left = TranslateSingleUnit(transform.Left!, deltaX);
        }

        public override void TranslateSize(EditorTransform transform, double deltaWidth, double deltaHeight)
        {
            transform.Width = TranslateSingleUnit(transform.Width!, deltaWidth);
        }

        public override void Build(StringBuilder builder, EditorTransform transform)
        {
            AppendAllAnchors(builder, transform.Left!, transform.Width!, transform.Top!, transform.Bottom!);
        }
    }
}