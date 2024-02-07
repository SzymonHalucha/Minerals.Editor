namespace Minerals.Editor.Anchors
{
    public record TopLeftAnchor() : EditorAnchor("left:", "width:", "top:", "height:")
    {
        public static TopLeftAnchor Default { get; } = new();

        public override void TranslatePosition(EditorTransform transform, double deltaX, double deltaY)
        {
            transform.Left = TranslateSingleUnit(transform.Left!, deltaX);
            transform.Top = TranslateSingleUnit(transform.Top!, deltaY);
        }

        public override void TranslateSize(EditorTransform transform, double deltaWidth, double deltaHeight)
        {
            transform.Width = TranslateSingleUnit(transform.Width!, deltaWidth);
            transform.Height = TranslateSingleUnit(transform.Height!, deltaHeight);
        }

        public override void Build(StringBuilder builder, EditorTransform transform)
        {
            AppendAllAnchors(builder, transform.Left!, transform.Width!, transform.Top!, transform.Height!);
        }
    }
}