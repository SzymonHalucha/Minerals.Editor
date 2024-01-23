namespace Minerals.Editor.States
{
    public class EditorStateSnapped : IEditorState
    {
        private IEditorWindow? _target;
        private IEditorWindow? _source;
        private IEditorWindow? _snapArea;
        private Point2D _size;
        private Point2D _position;
        private Point2D _deltaPosition = new(0, 0);

        public IEditorState OnSetup(IEditorWindow target, IEditorArgs[]? args = null)
        {
            _target = target;
            var sourceArgs = args?.FirstOrDefault(x => x is EditorArgsEventSource);
            _source = (sourceArgs as EditorArgsEventSource)!.Window;
            return this;
        }

        public IEditorState OnEnter(IEditorArgs[]? args = null)
        {
            var ignoreArgs = args?.FirstOrDefault(x => x is EditorArgsIgnoreEvents);
            if (ignoreArgs is EditorArgsIgnoreEvents ignore && ignore.Value)
            {
                _target!.SetCssStyle("pointer-events", "none");
            }

            _source!.SubscribeMouseEvent<EditorEventOnMouseMove>(TrackMouse);
            _source.Refresh();

            var snapAreaArgs = args?.FirstOrDefault(x => x is EditorArgsSnapArea);
            _snapArea = (snapAreaArgs as EditorArgsSnapArea)!.Window;

            _deltaPosition = new Point2D(0, 0);
            _position = _target!.Position;
            _size = _target.Size;
            _target.Position = _snapArea!.Position;
            _target.Size = _snapArea.Size;
            _target.Refresh();
            return this;
        }

        public IEditorState OnExit(IEditorArgs[]? args = null)
        {
            _source!.UnsubscribeMouseEvent<EditorEventOnMouseMove>(TrackMouse);
            _source.Refresh();

            _target!.SetCssStyle("pointer-events", "all");

            var saveArgs = args?.FirstOrDefault(x => x is EditorArgsSaveTransform);
            if (saveArgs is not EditorArgsSaveTransform save || !save.Value)
            {
                _target.Position = _position + _deltaPosition;
                _target.Size = _size;
            }

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

        private void TrackMouse(MouseEventArgs args)
        {
            _deltaPosition += new Point2D(args.MovementX, args.MovementY);
        }
    }
}