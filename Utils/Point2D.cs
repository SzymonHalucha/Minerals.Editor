namespace Minerals.Editor.Utils
{
    public struct Point2D(double x, double y)
    {
        public double X { get; set; } = x;
        public double Y { get; set; } = y;
        public double Width { readonly get => X; set => X = value; }
        public double Height { readonly get => Y; set => Y = value; }

        public readonly double LengthSquared => X * X + Y * Y;
        public readonly double Length => Math.Sqrt(LengthSquared);
        public readonly Point2D Normalized
        {
            get
            {
                var length = Length;
                return new(X / length, Y / length);
            }
        }

        public Point2D(double x) : this(x, 0) { }
        public Point2D(Tuple<double, double> value) : this(value.Item1, value.Item2) { }

        public static Point2D operator +(Point2D a, Point2D b) => new(a.X + b.X, a.Y + b.Y);
        public static Point2D operator -(Point2D a, Point2D b) => new(a.X - b.X, a.Y - b.Y);
        public static Point2D operator *(Point2D a, Point2D b) => new(a.X * b.X, a.Y * b.Y);
        public static Point2D operator /(Point2D a, Point2D b) => new(a.X / b.X, a.Y / b.Y);
        public static Point2D operator *(Point2D a, double b) => new(a.X * b, a.Y * b);
        public static Point2D operator /(Point2D a, double b) => new(a.X / b, a.Y / b);
    }
}