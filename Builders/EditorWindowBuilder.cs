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

        public IEditorWindowBuilder AddComponent<T>(out T component)
            where T : class, IEditorComponent, new()
        {
            component = _target!.AddOrGetComponent<T>();
            return this;
        }

        public IEditorWindowBuilder AddDefaultStyle()
        {
            EditorComponentStyles styles = _target!.GetComponent<EditorComponentStyles>()!;
            styles.AddClass(ThemeComponents.EditorComponent);
            styles.AddClass(ThemeComponents.WindowComponent);
            return this;
        }

        public IEditorWindowBuilder AddDefaultState()
        {
            EditorComponentStates states = _target!.GetComponent<EditorComponentStates>()!;
            states.AddState<EditorStateNormal>();
            states.ChangeState<EditorStateNormal, EditorStateNormal>();
            return this;
        }

        public IEditorWindowBuilder AddMovableFeature(IEditorWindow moveComponent)
        {
            EditorComponentStates states = _target!.GetComponent<EditorComponentStates>()!;
            states.AddState<EditorStateMoving>
            (
                stateArgs: [new EditorArgsEventSource { Source = _target!.Parent! }]
            );
            states.AddTransition<EditorTransitionOnMouseDown<EditorStateNormal, EditorStateMoving>>
            (
                transitionArgs: [new EditorArgsEventSource { Source = moveComponent }],
                enterStateArgs: [new EditorArgsIgnoreEvents()]
            );
            AddExitTransitions<EditorStateMoving>();
            return this;
        }

        public IEditorWindowBuilder AddClosableFeature(IEditorWindow closeComponent)
        {
            AddEnterStateAndTransition<EditorStateClosed>(closeComponent);
            return this;
        }

        public IEditorWindowBuilder AddResizableFeature(IEditorWindow resizeComponent)
        {
            AddEnterStateAndTransition<EditorStateResizing>(resizeComponent);
            AddExitTransitions<EditorStateResizing>();
            return this;
        }

        public IEditorWindowBuilder AddVerticalResizableFeature(IEditorWindow verticalResizeComponent)
        {
            AddEnterStateAndTransition<EditorStateVerticalResizing>(verticalResizeComponent);
            AddExitTransitions<EditorStateVerticalResizing>();
            return this;
        }

        public IEditorWindowBuilder AddHorizontalResizableFeature(IEditorWindow horizontalResizeComponent)
        {
            AddEnterStateAndTransition<EditorStateHorizontalResizing>(horizontalResizeComponent);
            AddExitTransitions<EditorStateHorizontalResizing>();
            return this;
        }

        public IEditorWindowBuilder AddSnappableFeature()
        {
            throw new NotImplementedException();
        }

        public IEditorWindowBuilder AddScrollableFeature()
        {
            throw new NotImplementedException();
        }

        public IEditorWindowBuilder AddClasses(string? classes)
        {
            if (classes != null)
            {
                StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
                string[] list = classes.Split(separator: ' ', options: splitOptions);

                EditorComponentStyles styles = _target!.GetComponent<EditorComponentStyles>()!;
                foreach (var cls in list)
                {
                    styles.AddClass(cls);
                }
            }
            return this;
        }

        public IEditorWindowBuilder SetTransform(EditorTransform? transform)
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

        public IEditorWindowBuilder SetThemes(IEditorThemes? themes)
        {
            if (themes != null)
            {
                EditorComponentThemes component = _target!.GetComponent<EditorComponentThemes>()!;
                component.SetThemes(themes);
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
            EditorComponentStates states = _target!.GetComponent<EditorComponentStates>()!;
            states.AddState<T>
            (
                stateArgs: [new EditorArgsEventSource { Source = _target.Parent }]
            );
            states.AddTransition<EditorTransitionOnMouseDown<EditorStateNormal, T>>
            (
                transitionArgs: [new EditorArgsEventSource { Source = source }]
            );
        }

        private void AddExitTransitions<T>() where T : IEditorState, new()
        {
            EditorComponentStates states = _target!.GetComponent<EditorComponentStates>()!;
            states.AddTransition<EditorTransitionOnMouseUp<T, EditorStateNormal>>
            (
                transitionArgs: [new EditorArgsEventSource { Source = _target.Parent }],
                exitStateArgs: [new EditorArgsSaveTransform()]
            );
            states.AddTransition<EditorTransitionOnMouseLeave<T, EditorStateNormal>>
            (
                transitionArgs: [new EditorArgsEventSource { Source = _target.Parent }]
            );
        }

        public static EditorWindow BuildHeaderWindow(IEditorWindow? parent)
        {
            EditorPoint position = new(0, 0);
            EditorPoint size = new(100, 32, EditorUnit.Percent, EditorUnit.Pixel);
            EditorAnchor anchor = EditorAnchor.Top | EditorAnchor.Left;
            EditorTransform transform = new(size, position, anchor);
            return CreateEventBaseComponent
            (
                transform,
                parent,
                ThemeComponents.HeaderComponent
            ).Build();
        }

        public static EditorWindow BuildCloseWindow(IEditorWindow? parent)
        {
            EditorPoint position = new(0, 0);
            EditorPoint size = new(32, 32);
            EditorAnchor anchor = EditorAnchor.Top | EditorAnchor.Right;
            EditorTransform transform = new(size, position, anchor);
            return CreateEventBaseComponent
            (
                transform,
                parent,
                ThemeComponents.CloseComponent
            ).Build();
        }

        public static EditorWindow BuildResizeWindow(IEditorWindow? parent)
        {
            EditorPoint position = new(0, 0);
            EditorPoint size = new(16, 16);
            EditorAnchor anchor = EditorAnchor.Bottom | EditorAnchor.Right;
            EditorTransform transform = new(size, position, anchor);
            return CreateEventBaseComponent
            (
                transform,
                parent,
                ThemeComponents.ResizeComponent
            ).Build();
        }

        public static EditorWindow BuildVerticalResizeWindow(IEditorWindow? parent)
        {
            EditorPoint position = new(0, 0);
            EditorPoint size = new(80, 16, EditorUnit.Percent, EditorUnit.Pixel);
            EditorAnchor anchor = EditorAnchor.Bottom | EditorAnchor.Right | EditorAnchor.Left;
            EditorTransform transform = new(size, position, anchor);
            return CreateEventBaseComponent
            (
                transform,
                parent,
                ThemeComponents.VerticalResizeComponent
            ).Build();
        }

        public static EditorWindow BuildHorizontalResizeWindow(IEditorWindow? parent)
        {
            EditorPoint position = new(0, 0);
            EditorPoint size = new(16, 80, EditorUnit.Pixel, EditorUnit.Percent);
            EditorAnchor anchor = EditorAnchor.Bottom | EditorAnchor.Top | EditorAnchor.Right;
            EditorTransform transform = new(size, position, anchor);
            return CreateEventBaseComponent
            (
                transform,
                parent,
                ThemeComponents.HorizontalResizeComponent
            ).Build();
        }

        private static EditorWindowBuilder CreateEventBaseComponent
        (
            EditorTransform transform,
            IEditorWindow? parent = null,
            string? classes = null
        )
        {
            return (EditorWindowBuilder)new EditorWindowBuilder()
                .CreateNew()
                .SetParent(parent)
                .SetTransform(transform)
                .AddComponent<EditorComponentEvents>(out _)
                .AddComponent<EditorComponentStyles>(out _)
                .AddClasses(classes)
                .AddDefaultStyle();
        }
    }
}