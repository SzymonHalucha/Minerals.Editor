namespace Minerals.Editor.Anchors
{
    public class VerticalLeftAnchor : EditorAnchorBase
    {
        public override string[] Anchors => ["left:", "width:", "top:", "bottom:"];

        public Unit Left { get => Units[0]; set => Units[0] = value; }
        public Unit Width { get => Units[1]; set => Units[1] = value; }
        public Unit Top { get => Units[2]; set => Units[2] = value; }
        public Unit Bottom { get => Units[3]; set => Units[3] = value; }

        public override void AddDeltaPosition(params double[] values)
        {
            Left = UpdateUnit(Left, values[0]);
            Top = UpdateUnit(Top, values[1]);
            Bottom = UpdateUnit(Bottom, values[2]);
        }

        public override void AddDeltaSize(params double[] values)
        {
            Width = UpdateUnit(Width, values[0]);
        }

        public override string Build()
        {
            Builder.Clear();
            AppendAllAnchors(Builder, Left, Width, Top, Bottom);
            return Builder.ToString();
        }
    }
}