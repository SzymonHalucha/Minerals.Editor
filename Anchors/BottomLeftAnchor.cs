namespace Minerals.Editor.Anchors
{
    public record BottomLeftAnchor() : Anchor("left:", "width:", "bottom:", "height:")
    {
        public static BottomLeftAnchor Default { get; } = new();

        public override void TranslatePosition(Transform transform, double deltaX, double deltaY)
        {
            transform.Left = TranslateSingleUnit(transform.Left, deltaX);
            transform.Bottom = TranslateSingleUnit(transform.Bottom, deltaY);
        }

        public override void TranslateSize(Transform transform, double deltaWidth, double deltaHeight)
        {
            transform.Width = TranslateSingleUnit(transform.Width, deltaWidth);
            transform.Height = TranslateSingleUnit(transform.Height, deltaHeight);
        }

        public override void Build(StringBuilder builder, Transform transform)
        {
            AppendAllAnchors(builder, transform.Left, transform.Width, transform.Bottom, transform.Height);
        }
    }
}