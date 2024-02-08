namespace Minerals.Editor.Anchors
{
    public record AllAnchor() : Anchor("left:", "right:", "top:", "bottom:")
    {
        public static AllAnchor Default { get; } = new();

        public override void TranslatePosition(Transform transform, double deltaX, double deltaY) { }

        public override void TranslateSize(Transform transform, double deltaWidth, double deltaHeight) { }

        public override void Build(StringBuilder builder, Transform transform)
        {
            AppendAllAnchors(builder, transform.Left, transform.Right, transform.Top, transform.Bottom);
        }
    }
}