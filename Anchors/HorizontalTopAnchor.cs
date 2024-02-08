namespace Minerals.Editor.Anchors
{
    public class HorizontalTopAnchor : EditorAnchorBase
    {
        public override string[] Anchors => ["left:", "right:", "top:", "height:"];

        public Unit Left { get => Units[0]; set => Units[0] = value; }
        public Unit Right { get => Units[1]; set => Units[1] = value; }
        public Unit Top { get => Units[2]; set => Units[2] = value; }
        public Unit Height { get => Units[3]; set => Units[3] = value; }

        public override void AddDeltaPosition(params double[] values)
        {
            Left = UpdateUnit(Left, values[0]);
            Right = UpdateUnit(Right, values[1]);
            Top = UpdateUnit(Top, values[2]);
        }

        public override void AddDeltaSize(params double[] values)
        {
            Height = UpdateUnit(Height, values[0]);
        }

        public override string Build()
        {
            Builder.Clear();
            AppendAllAnchors(Builder, Left, Right, Top, Height);
            return Builder.ToString();
        }
    }
}