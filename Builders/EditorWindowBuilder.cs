namespace Minerals.Editor.Builders
{
    public class EditorWindowBuilder : IEditorWindowBuilder
    {
        private IEditorWindow? _target;

        public IEditorWindowBuilder CreateNew()
        {
            return BuildForReference(new EditorWindow());
        }

        public IEditorWindowBuilder BuildForReference(IEditorWindow target)
        {
            _target = target;
            return this;
        }

        public IEditorWindowBuilder AddFeature<T>(out T feature)
            where T : class, IEditorFeature, new()
        {
            feature = _target!.AddOrGetFeature<T>();
            return this;
        }

        public IEditorWindowBuilder AddDefaultStyle()
        {
            EditorFeatureStyles styles = _target!.GetFeature<EditorFeatureStyles>()!;
            styles.AddClass(ThemeSelectors.EditorWindow);
            return this;
        }

        public IEditorWindowBuilder AddDefaultState()
        {
            EditorFeatureStates states = _target!.GetFeature<EditorFeatureStates>()!;
            states.AddState<NormalState>();
            states.ChangeState<NormalState, NormalState>();
            return this;
        }

        public IEditorWindowBuilder AddMoveState(IEditorWindow moveComponent)
        {
            EditorFeatureStates states = _target!.GetFeature<EditorFeatureStates>()!;
            states.AddState<MoveState>
            (
                stateArgs: [new EditorArgsEventSource { Source = _target!.Parent! }]
            );
            states.AddTransition<OnMouseDownTransition<NormalState, MoveState>>
            (
                transitionArgs: [new EditorArgsEventSource { Source = moveComponent }],
                enterStateArgs: [new EditorArgsIgnoreEvents()]
            );
            AddExitTransitions<MoveState>();
            return this;
        }

        public IEditorWindowBuilder AddCloseState(IEditorWindow closeComponent)
        {
            AddEnterStateAndTransition<CloseState>(closeComponent);
            return this;
        }

        public IEditorWindowBuilder AddResizeState(IEditorWindow resizeComponent)
        {
            AddEnterStateAndTransition<ResizeState>(resizeComponent);
            AddExitTransitions<ResizeState>();
            return this;
        }

        public IEditorWindowBuilder AddVerticalResizeState(IEditorWindow verticalResizeComponent)
        {
            AddEnterStateAndTransition<VerticalResizeState>(verticalResizeComponent);
            AddExitTransitions<VerticalResizeState>();
            return this;
        }

        public IEditorWindowBuilder AddHorizontalResizeState(IEditorWindow horizontalResizeComponent)
        {
            AddEnterStateAndTransition<HorizontalResizeState>(horizontalResizeComponent);
            AddExitTransitions<HorizontalResizeState>();
            return this;
        }

        public IEditorWindowBuilder AddSnapState()
        {
            throw new NotImplementedException();
        }

        public IEditorWindowBuilder AddScrollState()
        {
            throw new NotImplementedException();
        }

        public IEditorWindowBuilder AddClasses(string? classes)
        {
            if (classes != null)
            {
                const StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
                string[] list = classes.Split(separator: ' ', options: splitOptions);

                EditorFeatureStyles styles = _target!.GetFeature<EditorFeatureStyles>()!;
                foreach (var cls in list)
                {
                    styles.AddClass(cls);
                }
            }
            return this;
        }

        public IEditorWindowBuilder SetTransform(Transform? transform)
        {
            if (transform != null)
            {
                _target!.Transform = transform;
            }
            return this;
        }

        public IEditorWindowBuilder SetParent(IEditorWindow? parent)
        {
            parent?.AddChild(_target!);
            return this;
        }

        public IEditorWindowBuilder SetEditorThemes(IEditorThemes? themes)
        {
            if (themes != null)
            {
                EditorFeatureThemes feature = _target!.GetFeature<EditorFeatureThemes>()!;
                feature.EditorThemes = themes;
            }
            return this;
        }

        public IEditorWindowBuilder SetTag(string? tag)
        {
            if (tag != null)
            {
                _target!.Tag = tag;
            }
            return this;
        }

        public IEditorWindowBuilder SetId(string? id)
        {
            _target!.Id = id;
            return this;
        }

        public EditorWindow Build()
        {
            _target!.Enable = true;
            return (EditorWindow)_target;
        }

        private void AddEnterStateAndTransition<T>(IEditorWindow source) where T : IEditorState, new()
        {
            EditorFeatureStates states = _target!.GetFeature<EditorFeatureStates>()!;
            states.AddState<T>
            (
                stateArgs: [new EditorArgsEventSource { Source = _target.Parent }]
            );
            states.AddTransition<OnMouseDownTransition<NormalState, T>>
            (
                transitionArgs: [new EditorArgsEventSource { Source = source }]
            );
        }

        private void AddExitTransitions<T>() where T : IEditorState, new()
        {
            EditorFeatureStates states = _target!.GetFeature<EditorFeatureStates>()!;
            states.AddTransition<OnMouseUpTransition<T, NormalState>>
            (
                transitionArgs: [new EditorArgsEventSource { Source = _target.Parent }],
                exitStateArgs: [new EditorArgsSaveTransform()]
            );
            states.AddTransition<OnMouseLeaveTransition<T, NormalState>>
            (
                transitionArgs: [new EditorArgsEventSource { Source = _target.Parent }]
            );
        }
    }
}