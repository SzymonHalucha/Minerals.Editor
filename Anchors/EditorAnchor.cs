namespace Minerals.Editor.Anchors
{
    public abstract record Anchor(string Anchor1, string Anchor2, string Anchor3, string Anchor4)
    {
        public abstract void TranslatePosition(Transform transform, double deltaX, double deltaY);
        public abstract void TranslateSize(Transform transform, double deltaWidth, double deltaHeight);
        public abstract void Build(StringBuilder builder, Transform transform);

        protected static Unit TranslateSingleUnit(Unit unit1, double delta)
        {
            if (delta == 0)
            {
                return unit1;
            }

            switch (unit1)
            {
                case PixelUnit pixelUnit:
                    return new PixelUnit(pixelUnit.Number + delta);

                case OperatorUnit operatorUnit when operatorUnit.Right is PixelUnit pixelUnit:
                    return operatorUnit with { Right = new PixelUnit(pixelUnit.Number + delta) };

                case OperatorUnit operatorUnit:
                    return new OperatorUnit(operatorUnit, new PixelUnit(delta), "+");

                default:
                    return new OperatorUnit(unit1, new PixelUnit(delta), "+");
            }
        }

        protected void AppendAllAnchors(StringBuilder builder, Unit unit1, Unit unit2, Unit unit3, Unit unit4)
        {
            AppendSingleAnchor(builder, unit1, Anchor1);
            AppendSingleAnchor(builder, unit2, Anchor2);
            AppendSingleAnchor(builder, unit3, Anchor3);
            AppendSingleAnchor(builder, unit4, Anchor4);
        }

        private static void AppendSingleAnchor(StringBuilder builder, Unit unit, string anchor)
        {
            builder.Append(anchor);
            switch (unit)
            {
                case OperatorUnit:
                    builder.Append("calc");
                    unit.Build(builder);
                    break;
                case NumberUnit:
                    unit.Build(builder);
                    break;
            }

            builder.Append(';');
        }
    }
}