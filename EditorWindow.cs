namespace Minerals.Editor
{
    public class EditorWindow : ComponentBase, IEditorWindow
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
        public string? Id { get; set; }
        public string Tag { get; set; } = "div";

        public EditorTransform Transform { get; set; } = new();
        public IEditorWindow? Parent { get; set; }
        public bool Enable { get; set; } = false;

        private readonly List<IEditorWindow> _children = [];
        private readonly List<IEditorComponent> _components = [];

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (Enable && Parent == null)
            {
                BuildTree(builder);
            }
        }

        private void BuildTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, Tag);
            SetIdAttribute(builder);
            if (_components.Count > 0)
            {
                SetComponentsAttributes(builder);
                SetComponentsContent(builder);
            }
            SetChildContent(builder);
            builder.CloseElement();
        }

        private void SetIdAttribute(RenderTreeBuilder builder)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                builder.AddAttribute(1, "id", Id);
            }
        }

        private void SetComponentsAttributes(RenderTreeBuilder builder)
        {
            foreach (IEditorComponent item in _components)
            {
                item.AppendAttributes(2, builder);
            }
        }

        private void SetComponentsContent(RenderTreeBuilder builder)
        {
            builder.OpenRegion(3);
            foreach (IEditorComponent item in _components)
            {
                item.AppendContent(builder);
            }
            builder.CloseRegion();
        }

        private void SetChildContent(RenderTreeBuilder builder)
        {
            if (_children.Count > 0)
            {
                builder.OpenRegion(4);
                foreach (var child in _children)
                {
                    if (child.Enable)
                    {
                        child.SetContent(builder);
                    }
                }
                builder.CloseRegion();
            }
            builder.AddContent(5, ChildContent);
        }

        public IEditorWindow SetContent(RenderTreeBuilder builder)
        {
            BuildTree(builder);
            return this;
        }

        public IEditorWindow AddChild(IEditorWindow window)
        {
            window.Parent = this;
            _children.Add(window);
            return this;
        }

        public IEditorWindow RemoveChild(IEditorWindow window)
        {
            window.Parent = null;
            _children.Remove(window);
            return this;
        }

        public bool HasChild(IEditorWindow window)
        {
            return _children.Contains(window);
        }

        public T? AddComponent<T>() where T : class, IEditorComponent, new()
        {
            if (!_components.Any(c => c is T))
            {
                T component = new();
                component.SetupComponent(this);
                _components.Add(component);
                return component;
            }
            return null;
        }

        public T? RemoveComponent<T>() where T : class, IEditorComponent, new()
        {
            T? component = _components.FirstOrDefault(c => c is T) as T;
            if (component != null)
            {
                _components.Remove(component);
            }
            return component;
        }

        public T? GetComponent<T>() where T : class, IEditorComponent, new()
        {
            return _components.FirstOrDefault(c => c is T) as T;
        }

        public T AddOrGetComponent<T>() where T : class, IEditorComponent, new()
        {
            if (!_components.Any(c => c is T))
            {
                T component = new();
                component.SetupComponent(this);
                _components.Add(component);
                return component;
            }
            else
            {
                return (T)_components.First(c => c is T);
            }
        }

        public bool HasComponent<T>() where T : class, IEditorComponent, new()
        {
            return _components.Any(c => c is T);
        }

        public IEditorWindow Refresh()
        {
            StateHasChanged();
            return this;
        }
    }
}