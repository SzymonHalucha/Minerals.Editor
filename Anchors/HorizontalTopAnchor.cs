namespace Minerals.Editor.Anchors
{
    public record HorizontalTopAnchor() : Anchor("left:", "right:", "top:", "height:")
    {
        public static HorizontalTopAnchor Default { get; } = new();

        public override void TranslatePosition(Transform transform, double deltaX, double deltaY)
        {
            transform.Top = TranslateSingleUnit(transform.Top, deltaY);
        }

        public override void TranslateSize(Transform transform, double deltaWidth, double deltaHeight)
        {
            transform.Height = TranslateSingleUnit(transform.Height, deltaHeight);
        }

        public override void Build(StringBuilder builder, Transform transform)
        {
            AppendAllAnchors(builder, transform.Left, transform.Right, transform.Top, transform.Height);
        }
    }
}