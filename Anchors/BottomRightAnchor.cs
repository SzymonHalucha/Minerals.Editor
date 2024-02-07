namespace Minerals.Editor.Anchors
{
    public record BottomRightAnchor() : EditorAnchor("right:", "width:", "bottom:", "height:")
    {
        public static BottomRightAnchor Default { get; } = new();

        public override void TranslatePosition(EditorTransform transform, double deltaX, double deltaY)
        {
            transform.Right = TranslateSingleUnit(transform.Right, deltaX);
            transform.Bottom = TranslateSingleUnit(transform.Bottom, deltaY);
        }

        public override void TranslateSize(EditorTransform transform, double deltaWidth, double deltaHeight)
        {
            transform.Width = TranslateSingleUnit(transform.Width, deltaWidth);
            transform.Height = TranslateSingleUnit(transform.Height, deltaHeight);
        }

        public override void Build(StringBuilder builder, EditorTransform transform)
        {
            AppendAllAnchors(builder, transform.Right, transform.Width, transform.Bottom, transform.Height);
        }
    }
}