namespace Minerals.Editor.Args
{
    public class EditorArgsCondition(Func<bool> condition) : IEditorArgs
    {
        public readonly Func<bool> Condition = condition;
    }
}