namespace Minerals.Editor.Args
{
    public abstract class EditorArgsBooleanBase(bool value) : IEditorArgs
    {
        public bool Value { get; init; } = value;
    }
}