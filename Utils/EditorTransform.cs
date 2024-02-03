namespace Minerals.Editor.Utils
{
    //FIX: Optimize this for performance allocation and better handling anchors (EditorTransform)
    public class EditorTransform(EditorPoint size, EditorPoint position, EditorAnchor anchor)
    {
        public EditorPoint Size { get; set; } = size;
        public EditorPoint Position { get; set; } = position;
        public EditorAnchor Anchor { get; set; } = anchor;

        public EditorTransform(EditorPoint size, EditorPoint position) : this(size, position, EditorAnchor.Top | EditorAnchor.Left) { }
        public EditorTransform(EditorPoint size) : this(size, new EditorPoint(0, 0)) { }
        public EditorTransform() : this(new EditorPoint(100, 100)) { }
    }
}