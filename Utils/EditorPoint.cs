namespace Minerals.Editor.Utils
{
    public readonly record struct EditorPoint(double X, double Y, EditorUnit XUnit, EditorUnit YUnit)
    {
        public double Width => X;
        public double Height => Y;

        public EditorPoint(double x, double y, EditorUnit unit) : this(x, y, unit, unit) { }
        public EditorPoint(double x, double y) : this(x, y, EditorUnit.Pixel) { }
        public EditorPoint(double x) : this(x, 0) { }
        public EditorPoint() : this(0) { }
    }
}