namespace Minerals.Editor.Utils
{
    public class Transform
    {
        public Anchor Anchor { get; set; } = TopLeftAnchor.Default;

        public Unit Left { get; set; } = new PixelUnit(0);
        public Unit Right { get; set; } = new PixelUnit(0);
        public Unit Top { get; set; } = new PixelUnit(0);
        public Unit Bottom { get; set; } = new PixelUnit(0);

        public Unit Width { get; set; } = new PixelUnit(0);
        public Unit Height { get; set; } = new PixelUnit(0);

        private readonly StringBuilder _builder = new();

        public string Build()
        {
            _builder.Clear();
            Anchor.Build(_builder, this);
            return _builder.ToString();
        }

        public void TranslatePosition(double deltaX, double deltaY)
        {
            Anchor.TranslatePosition(this, deltaX, deltaY);
        }

        public void TranslateSize(double deltaWidth, double deltaHeight)
        {
            Anchor.TranslateSize(this, deltaWidth, deltaHeight);
        }

        public override string ToString() => Build();
    }
}