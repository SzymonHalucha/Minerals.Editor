namespace Minerals.Editor.States
{
    public class EditorStateNormal : IEditorState
    {
        private IEditorWindow? _target;

        public IEditorState OnSetup(IEditorWindow target, IEditorArgs[]? args = null)
        {
            _target = target;
            return this;
        }

        public IEditorState OnEnter(IEditorArgs[]? args = null) => this;
        public IEditorState OnExit(IEditorArgs[]? args = null) => this;
        public IEditorState OnDestroy(IEditorArgs[]? args = null) => this;
        public IEditorWindow GetWindow() => _target!;
    }
}