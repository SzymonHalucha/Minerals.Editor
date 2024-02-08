namespace Minerals.Editor.Anchors
{
    public class HorizontalBottomAnchor : EditorAnchorBase
    {
        public override string[] Anchors => ["left:", "right:", "bottom:", "height:"];

        public Unit Left { get => Units[0]; set => Units[0] = value; }
        public Unit Right { get => Units[1]; set => Units[1] = value; }
        public Unit Bottom { get => Units[2]; set => Units[2] = value; }
        public Unit Height { get => Units[3]; set => Units[3] = value; }

        public override void AddDeltaPosition(params double[] values)
        {
            Left = UpdateUnit(Left, values[0]);
            Right = UpdateUnit(Right, values[1]);
            Bottom = UpdateUnit(Bottom, values[2]);
        }

        public override void AddDeltaSize(params double[] values)
        {
            Height = UpdateUnit(Height, values[0]);
        }

        public override string Build()
        {
            Builder.Clear();
            AppendAllAnchors(Builder, Left, Right, Bottom, Height);
            return Builder.ToString();
        }
    }
}