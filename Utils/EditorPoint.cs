namespace Minerals.Editor.Utils
{
    public readonly record struct EditorPoint(in EditorUnit X, in EditorUnit Y)
    {
        public readonly EditorUnit Width => X;
        public readonly EditorUnit Height => Y;

        public EditorPoint(double x, double y) : this(new PixelUnit(x), new PixelUnit(y)) { }
        public EditorPoint(EditorUnit x, double y) : this(x, new PixelUnit(y)) { }
        public EditorPoint(double x, EditorUnit y) : this(new PixelUnit(x), y) { }
        public EditorPoint(double value) : this(value, value) { }
        public EditorPoint() : this(0) { }
    }
}