namespace Minerals.Editor.Anchors
{
    public interface IEditorAnchor
    {
        public string[] Anchors { get; }
        public Unit[] Units { get; }

        public void AddDeltaPosition(params double[] values);
        public void AddDeltaSize(params double[] values);
        public string Build();
    }
}