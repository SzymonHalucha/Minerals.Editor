namespace Minerals.Editor.Args
{
    public class EditorArgsEventSource : IEditorArgs
    {
        public IEditorWindow? Source { get; init; }
    }
}