namespace Minerals.Editor
{
    public class EditorWindow : ComponentBase, IEditorWindow
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter] public string Tag { get; set; } = "div";
        [Parameter] public string? Id { get; set; }
        [Parameter] public string? Class { get; set; }
        [Parameter] public string? Title { get; set; }

        public IEditorWindow? Root { get; set; }
        public IEditorWindow? Parent { get; set; }

        public Point2D Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                SetCssStyle("left", $"{_position.X}px");
                SetCssStyle("top", $"{_position.Y}px");
            }
        }

        public Point2D Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                SetCssStyle("width", $"{_size.Width}px");
                SetCssStyle("height", $"{_size.Height}px");
            }
        }

        public bool Enabled { get; set; } = true;

        private readonly Dictionary<string, string> _styles = [];
        private readonly List<string> _classes = [];
        private readonly List<IEditorWindow> _children = [];
        private readonly List<IEditorEvent<MouseEventArgs>> _mouseEvents = [];
        private readonly List<IEditorTransition> _transitions = [];
        private readonly List<IEditorState> _states = [];
        private IEditorState? _currentState;

        private bool _instancedFromCode = false;
        private Point2D _position = new(0, 0);
        private Point2D _size = new(100, 100);

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (Enabled && !_instancedFromCode)
            {
                BuildTree(builder);
            }
        }

        private void BuildTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag);
            builder.AddAttribute(1, "Id", Id);
            SetClassAttribute(builder);
            SetStyleAttribute(builder);
            SetEventsAttributes(builder);
            RenderChildrenContent(builder);
            builder.CloseElement();
        }

        //TODO: Optimize this
        private void SetClassAttribute(RenderTreeBuilder builder)
        {
            string text = string.Empty;

            if (Class != null)
            {
                text = Class;
                text += " ";
            }

            foreach (var item in _classes)
            {
                text += $"{item} ";
            }

            if (text != string.Empty)
            {
                builder.AddAttribute(3, "class", text);
            }
        }

        //TODO: Optimize this
        private void SetStyleAttribute(RenderTreeBuilder builder)
        {
            string text = string.Empty;
            foreach (var item in _styles)
            {
                text += $"{item.Key}:{item.Value};";
            }

            if (text != string.Empty)
            {
                builder.AddAttribute(4, "style", text);
            }
        }

        private void OnThemeChanged(Theme theme)
        {
            Refresh();
        }

        private void SetEventsAttributes(RenderTreeBuilder builder)
        {
            if (_mouseEvents.Count > 0)
            {
                foreach (var evt in _mouseEvents)
                {
                    builder.AddAttribute(6, evt.Name, evt.Raise);
                }
            }
        }

        private void RenderChildrenContent(RenderTreeBuilder builder)
        {
            if (_children.Count > 0)
            {
                builder.OpenRegion(10);
                foreach (var child in _children)
                {
                    if (child.Enabled)
                    {
                        builder.AddContent(0, child.GetContent());
                    }
                }
                builder.CloseRegion();
            }
            builder.AddContent(11, ChildContent);
        }

        public IEditorWindow SetTag(string tag)
        {
            Tag = tag;
            return this;
        }

        public IEditorWindow SetId(string id)
        {
            Id = id;
            return this;
        }

        public IEditorWindow SetTitle(string title)
        {
            Title = title;
            return this;
        }

        public IEditorWindow SetChildContent(Action<RenderTreeBuilder> builder)
        {
            ChildContent = builder.Invoke;
            return this;
        }

        public RenderFragment GetContent()
        {
            return BuildTree;
        }

        public IEditorWindow Refresh()
        {
            if (_instancedFromCode)
            {
                Parent?.Refresh();
            }
            else
            {
                StateHasChanged();
            }
            return this;
        }

        public IEditorWindow SetCssStyle(string property, string value)
        {
            _styles[property] = value;
            return this;
        }

        public IEditorWindow AddCssClass(string name)
        {
            _classes.Add(name);
            return this;
        }

        public IEditorWindow RemoveCssClass(string name)
        {
            _classes.Remove(name);
            return this;
        }

        public IEditorWindow AddChildWindow(IEditorWindow child)
        {
            _children.Add(child);
            child.SetParent(this);
            return this;
        }

        public IEditorWindow RemoveChildWindow(IEditorWindow child)
        {
            _children.Remove(child);
            child.SetParent(null);
            return this;
        }

        public IEditorWindow SetParent(IEditorWindow? parent)
        {
            Parent = parent;
            _instancedFromCode = parent != null;
            return this;
        }

        public IEditorWindow SetRoot(IEditorWindow root)
        {
            Root = root;
            return this;
        }

        public IEditorWindow AddState<T>(IEditorArgs[]? stateArgs = null)
            where T : IEditorState, new()
        {
            if (_states.Any(x => x is T))
            {
                throw new Exception("This type of state already exists");
            }

            IEditorState state = new T();
            state.OnSetup(this, stateArgs);
            _states.Add(state);
            return this;
        }

        public IEditorWindow ChangeState<T>
        (
            IEditorArgs[]? exitStateArgs = null,
            IEditorArgs[]? enterStateArgs = null
        ) where T : IEditorState, new()
        {
            _currentState?.OnExit(exitStateArgs);
            _currentState = _states.FirstOrDefault(x => x is T);
            _currentState!.OnEnter(enterStateArgs);
            return this;
        }

        public bool IsCurrentState<T>() where T : IEditorState, new()
        {
            return _currentState is T;
        }

        public bool HasState<T>() where T : IEditorState, new()
        {
            return _states.Any(x => x is T);
        }

        public IEditorWindow AddTransition<T>
        (
            IEditorArgs[]? transitionArgs = null,
            IEditorArgs[]? exitStateArgs = null,
            IEditorArgs[]? enterStateArgs = null
            ) where T : IEditorTransition, new()
        {
            var transition = new T();
            transition.OnSetup(this, transitionArgs, exitStateArgs, enterStateArgs);
            _transitions.Add(transition);
            return this;
        }

        public IEditorWindow SubscribeMouseEvent<T>(Action<MouseEventArgs> action)
            where T : IEditorEvent<MouseEventArgs>, new()
        {
            var evt = _mouseEvents.FirstOrDefault(x => x is T);
            evt ??= new T();
            evt.Subscribe(action);
            _mouseEvents.Add(evt);
            return this;
        }

        public IEditorWindow UnsubscribeMouseEvent<T>(Action<MouseEventArgs> action)
            where T : IEditorEvent<MouseEventArgs>, new()
        {
            var evt = _mouseEvents.FirstOrDefault(x => x is T);
            evt?.Unsubscribe(action);
            return this;
        }
    }
}