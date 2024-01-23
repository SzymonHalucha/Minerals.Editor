namespace Minerals.Editor.States
{
    public class EditorStateClose : IEditorState
    {
        private IEditorWindow? _target;

        public IEditorState OnSetup(IEditorWindow target, IEditorArgs[]? args = null)
        {
            _target = target;
            return this;
        }

        public IEditorState OnEnter(IEditorArgs[]? args = null)
        {
            _target!.Enabled = false;
            _target.Refresh();
            return this;
        }

        public IEditorState OnExit(IEditorArgs[]? args = null)
        {
            _target!.Enabled = true;
            _target.Refresh();
            return this;
        }

        public IEditorState OnDestroy(IEditorArgs[]? args = null)
        {
            return this;
        }

        public IEditorWindow GetWindow()
        {
            return _target!;
        }
    }
}