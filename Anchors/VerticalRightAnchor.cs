namespace Minerals.Editor.Anchors
{
    public record VerticalRightAnchor() : Anchor("right:", "width:", "top:", "bottom:")
    {
        public static VerticalRightAnchor Default { get; } = new();

        public override void TranslatePosition(Transform transform, double deltaX, double deltaY)
        {
            transform.Right = TranslateSingleUnit(transform.Right, deltaX);
        }

        public override void TranslateSize(Transform transform, double deltaWidth, double deltaHeight)
        {
            transform.Width = TranslateSingleUnit(transform.Width, deltaWidth);
        }

        public override void Build(StringBuilder builder, Transform transform)
        {
            AppendAllAnchors(builder, transform.Right, transform.Width, transform.Top, transform.Bottom);
        }
    }
}