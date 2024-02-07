namespace Minerals.Editor.Anchors
{
    public record TopRightAnchor() : EditorAnchor("right:", "width:", "top:", "height:")
    {
        public static TopRightAnchor Default { get; } = new();

        public override void TranslatePosition(EditorTransform transform, double deltaX, double deltaY)
        {
            transform.Right = TranslateSingleUnit(transform.Right, deltaX);
            transform.Top = TranslateSingleUnit(transform.Top, deltaY);
        }

        public override void TranslateSize(EditorTransform transform, double deltaWidth, double deltaHeight)
        {
            transform.Width = TranslateSingleUnit(transform.Width, deltaWidth);
            transform.Height = TranslateSingleUnit(transform.Height, deltaHeight);
        }

        public override void Build(StringBuilder builder, EditorTransform transform)
        {
            AppendAllAnchors(builder, transform.Right, transform.Width, transform.Top, transform.Height);
        }
    }
}