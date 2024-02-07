namespace Minerals.Editor.Utils
{
    public class EditorTransform
    {
        public EditorAnchor Anchor { get; set; } = TopLeftAnchor.Default;

        public EditorUnit Left { get; set; } = new PixelUnit(0);
        public EditorUnit Right { get; set; } = new PixelUnit(0);
        public EditorUnit Top { get; set; } = new PixelUnit(0);
        public EditorUnit Bottom { get; set; } = new PixelUnit(0);

        public EditorUnit Width { get; set; } = new PixelUnit(0);
        public EditorUnit Height { get; set; } = new PixelUnit(0);

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