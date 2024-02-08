namespace Minerals.Editor.Anchors
{
    public class BottomRightAnchor : EditorAnchorBase
    {
        public override string[] Anchors => ["right:", "width:", "bottom:", "height:"];

        public Unit Right { get => Units[0]; set => Units[0] = value; }
        public Unit Width { get => Units[1]; set => Units[1] = value; }
        public Unit Bottom { get => Units[2]; set => Units[2] = value; }
        public Unit Height { get => Units[3]; set => Units[3] = value; }

        public override void AddDeltaPosition(params double[] values)
        {
            Right = UpdateUnit(Right, values[0]);
            Bottom = UpdateUnit(Bottom, values[1]);
        }

        public override void AddDeltaSize(params double[] values)
        {
            Width = UpdateUnit(Width, values[0]);
            Height = UpdateUnit(Height, values[1]);
        }

        public override string Build()
        {
            Builder.Clear();
            AppendAllAnchors(Builder, Right, Width, Bottom, Height);
            return Builder.ToString();
        }
    }
}