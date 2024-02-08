namespace Minerals.Editor.Utils
{
    public abstract record Unit(string Text)
    {
        public static EquationUnit operator +(Unit left, Unit right) =>
            new(left, right, "+");
        public static EquationUnit operator -(Unit left, Unit right) =>
            new(left, right, "-");
        public static EquationUnit operator *(Unit left, Unit right) =>
            new(left, right, "*");
        public static EquationUnit operator /(Unit left, Unit right) =>
            new(left, right, "/");

        public abstract void Build(StringBuilder builder);
    }

    public abstract record NumberUnit(double Number, string Text) : Unit(Text)
    {
        public override void Build(StringBuilder builder)
        {
            builder.Append(Number);
            builder.Append(Text);
        }
    }

    public record EquationUnit(Unit Left, Unit Right, string Text) : Unit(Text)
    {
        public override void Build(StringBuilder builder)
        {
            builder.Append('(');
            Left.Build(builder);
            builder.Append(Text);
            Right.Build(builder);
            builder.Append(')');
        }
    }

    public record PixelUnit(double Number) : NumberUnit(Number, "px");
    public record PercentUnit(double Number) : NumberUnit(Number, "%");
    public record ViewportWidthUnit(double Number) : NumberUnit(Number, "vw");
    public record ViewportHeightUnit(double Number) : NumberUnit(Number, "vh");
    public record ViewportMinUnit(double Number) : NumberUnit(Number, "vmin");
    public record ViewportMaxUnit(double Number) : NumberUnit(Number, "vmax");
    public record EmUnit(double Number) : NumberUnit(Number, "em");
    public record RemUnit(double Number) : NumberUnit(Number, "rem");
}