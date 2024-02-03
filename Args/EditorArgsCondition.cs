namespace Minerals.Editor.Args
{
    public class EditorArgsCondition : IEditorArgs
    {
        public Func<bool>? Condition { get; init; }
    }
}