namespace Minerals.Editor.Anchors
{
    public record HorizontalBottomAnchor() : EditorAnchor("left:", "right:", "bottom:", "height:")
    {
        public static HorizontalBottomAnchor Default { get; } = new();

        public override void TranslatePosition(EditorTransform transform, double deltaX, double deltaY)
        {
            transform.Bottom = TranslateSingleUnit(transform.Bottom, deltaY);
        }

        public override void TranslateSize(EditorTransform transform, double deltaWidth, double deltaHeight)
        {
            transform.Height = TranslateSingleUnit(transform.Height, deltaHeight);
        }

        public override void Build(StringBuilder builder, EditorTransform transform)
        {
            AppendAllAnchors(builder, transform.Left, transform.Right, transform.Bottom, transform.Height);
        }
    }
}