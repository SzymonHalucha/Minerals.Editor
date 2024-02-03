namespace Minerals.Editor.Utils
{
    [Flags]
    public enum EditorAnchor : int
    {
        None = 0,
        Left = 1,
        Right = 2,
        Top = 4,
        Bottom = 8
    }
}