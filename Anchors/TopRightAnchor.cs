namespace Minerals.Editor.Anchors
{
    public class TopRightAnchor : EditorAnchorBase
    {
        public override string[] Anchors => ["right:", "width:", "top:", "height:"];

        public Unit Right { get => Units[0]; set => Units[0] = value; }
        public Unit Width { get => Units[1]; set => Units[1] = value; }
        public Unit Top { get => Units[2]; set => Units[2] = value; }
        public Unit Height { get => Units[3]; set => Units[3] = value; }

        public override void AddDeltaPosition(params double[] values)
        {
            Right = UpdateUnit(Right, values[0]);
            Top = UpdateUnit(Top, values[1]);
        }

        public override void AddDeltaSize(params double[] values)
        {
            Width = UpdateUnit(Width, values[0]);
            Height = UpdateUnit(Height, values[1]);
        }

        public override string Build()
        {
            Builder.Clear();
            AppendAllAnchors(Builder, Right, Width, Top, Height);
            return Builder.ToString();
        }
    }
}