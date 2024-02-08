
namespace Minerals.Editor.Anchors
{
    public abstract class EditorAnchorBase : IEditorAnchor
    {
        public abstract string[] Anchors { get; }

        public Unit[] Units { get; } = [new PixelUnit(0), new PixelUnit(0), new PixelUnit(0), new PixelUnit(0)];
        protected readonly StringBuilder Builder = new();

        public abstract void AddDeltaPosition(params double[] values);
        public abstract void AddDeltaSize(params double[] values);
        public abstract string Build();

        protected void AppendAllAnchors(StringBuilder builder, Unit unit1, Unit unit2, Unit unit3, Unit unit4)
        {
            AppendSingleUnit(builder, unit1, Anchors[0]);
            AppendSingleUnit(builder, unit2, Anchors[1]);
            AppendSingleUnit(builder, unit3, Anchors[2]);
            AppendSingleUnit(builder, unit4, Anchors[3]);
        }

        protected static void AppendSingleUnit(StringBuilder builder, Unit unit, string anchor)
        {
            builder.Append(anchor);
            if (unit is EquationUnit)
            {
                builder.Append("calc");
            }
            unit.Build(builder);
            builder.Append(';');
        }

        protected static Unit UpdateUnit(Unit unit, double value)
        {
            if (value == 0)
            {
                return unit;
            }
            if (unit is PixelUnit pixel)
            {
                return new PixelUnit(pixel.Number + value);
            }
            if (unit is EquationUnit equation && equation.Right is PixelUnit right)
            {
                return equation with { Right = new PixelUnit(right.Number + value) };
            }

            return new EquationUnit(unit, new PixelUnit(value), "+");
        }
    }
}