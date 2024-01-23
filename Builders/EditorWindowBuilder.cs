namespace Minerals.Editor.Builders
{
    public class EditorWindowBuilder : IEditorWindowBuilder
    {
        private IEditorWindow? _target;
        private EditorWindow? _header;
        private EditorWindow? _closer;
        private EditorWindow? _resizer;
        private EditorWindow? _resizerHorizontal;
        private EditorWindow? _resizerVertical;

        public IEditorWindowBuilder CreateNew()
        {
            return BuildForReference(new EditorWindow());
        }

        public IEditorWindowBuilder BuildForReference(IEditorWindow target)
        {
            _target = target;
            _target.AddCssClass("editor-window");
            CreateDefaultStateIfDoesntExist();
            return this;
        }

        public IEditorWindowBuilder SetRoot(IEditorWindow root)
        {
            _target!.SetRoot(root);
            return this;
        }

        public IEditorWindowBuilder SetParameters(string? tag = null, string? id = null, string? title = null)
        {
            if (tag != null)
            {
                _target!.SetTag(tag);
            }

            if (id != null)
            {
                _target!.SetId(id);
            }

            if (title != null)
            {
                _target!.SetTitle(title);
            }

            return this;
        }

        public IEditorWindowBuilder SetPositionAndSize(Point2D position, Point2D size)
        {
            _target!.Position = position;
            _target!.Size = size;
            return this;
        }

        public IEditorWindowBuilder AddCloseFeature()
        {
            _closer = CreateDefaultComponent("editor-window-closer");
            AddDefaultEnterStatesAndTransitions<EditorStateClose>(_closer);
            return this;
        }

        public IEditorWindowBuilder AddSnapFeature(IEditorWindow[] snappers)
        {
            _target!.AddState<EditorStateSnapped>([new EditorArgsEventSource(_target!.Root!)]);
            foreach (var item in snappers)
            {
                _target.AddTransition<EditorTransitionOnMouseEnter<EditorStateMove, EditorStateSnapped>>
                (
                    transitionArgs: [new EditorArgsEventSource(item)],
                    enterStateArgs: [new EditorArgsSnapArea(item)]
                );
                _target.AddTransition<EditorTransitionOnMouseLeave<EditorStateSnapped, EditorStateMove>>
                (
                    transitionArgs: [new EditorArgsEventSource(item)],
                    exitStateArgs: [new EditorArgsSaveTransform()]
                );
            }
            AddDefaultExitStatesAndTransitions<EditorStateSnapped>();
            return this;
        }

        public IEditorWindowBuilder AddMoveFeature()
        {
            _header = CreateDefaultHeaderComponent();
            _target!.AddState<EditorStateMove>([new EditorArgsEventSource(_target!.Root!)]);
            _target.AddTransition<EditorTransitionOnMouseDown<EditorStateNormal, EditorStateMove>>
            (
                transitionArgs: [new EditorArgsEventSource(_header!)],
                enterStateArgs: [new EditorArgsIgnoreEvents()]
            );
            AddDefaultExitStatesAndTransitions<EditorStateMove>();
            return this;
        }

        public IEditorWindowBuilder AddResizeFeature()
        {
            _resizer = CreateDefaultComponent("editor-window-resizer");
            AddDefaultEnterStatesAndTransitions<EditorStateResize>(_resizer);
            AddDefaultExitStatesAndTransitions<EditorStateResize>();
            return this;
        }

        public IEditorWindowBuilder AddResizeHorizontalFeature()
        {
            _resizerHorizontal = CreateDefaultComponent("editor-window-resizer-horizontal");
            AddDefaultEnterStatesAndTransitions<EditorStateResizeHorizontal>(_resizerHorizontal);
            AddDefaultExitStatesAndTransitions<EditorStateResizeHorizontal>();
            return this;
        }

        public IEditorWindowBuilder AddResizeVerticalFeature()
        {
            _resizerVertical = CreateDefaultComponent("editor-window-resizer-vertical");
            AddDefaultEnterStatesAndTransitions<EditorStateResizeVertical>(_resizerVertical);
            AddDefaultExitStatesAndTransitions<EditorStateResizeVertical>();
            return this;
        }

        public IEditorWindow Build()
        {
            return _target!;
        }

        private void CreateDefaultStateIfDoesntExist()
        {
            if (!_target!.HasState<EditorStateNormal>())
            {
                _target.AddState<EditorStateNormal>();
                _target.ChangeState<EditorStateNormal>();
            }
        }

        private EditorWindow CreateDefaultHeaderComponent()
        {
            EditorWindow window = new();
            window.AddCssClass("editor-window-header")
            .SetTag("div")
            .SetChildContent(builder =>
            {
                builder.OpenElement(1, "h2");
                builder.AddContent(2, _target!.Title);
                builder.CloseElement();
            });
            _target!.AddChildWindow(window);
            return window;
        }

        private EditorWindow CreateDefaultComponent(string cssClassName)
        {
            EditorWindow window = new();
            window.AddCssClass(cssClassName)
            .SetTag("div");
            _target!.AddChildWindow(window);
            return window;
        }

        private void AddDefaultEnterStatesAndTransitions<T>(IEditorWindow activator)
            where T : IEditorState, new()
        {
            _target!.AddState<T>([new EditorArgsEventSource(_target!.Root!)]);
            _target!.AddTransition<EditorTransitionOnMouseDown<EditorStateNormal, T>>
            (
                transitionArgs: [new EditorArgsEventSource(activator)]
            );
        }

        private void AddDefaultExitStatesAndTransitions<T>()
            where T : IEditorState, new()
        {
            _target!.AddTransition<EditorTransitionOnMouseUp<T, EditorStateNormal>>
            (
                transitionArgs: [new EditorArgsEventSource(_target!.Root!)],
                exitStateArgs: [new EditorArgsSaveTransform()]
            );
            _target!.AddTransition<EditorTransitionOnMouseLeave<T, EditorStateNormal>>
            (
                transitionArgs: [new EditorArgsEventSource(_target!.Root!)],
                exitStateArgs: [new EditorArgsSaveTransform(false)]
            );
        }
    }
}