namespace Minerals.Editor
{
    public class EditorWindow : ComponentBase, IEditorWindow
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
        public string? Id { get; set; }
        public string Tag { get; set; } = "div";

        public Transform Transform { get; set; } = new();
        public IEditorWindow? Parent { get; set; }
        public bool Enable { get; set; } = false;

        private readonly List<IEditorWindow> _children = [];
        private readonly List<IEditorFeature> _features = [];

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
            AppendIdAttribute(builder);
            if (_features.Count > 0)
            {
                AppendFeaturesAttributes(builder);
                AppendFeaturesContent(builder);
            }
            AppendChildContent(builder);
            builder.CloseElement();
        }

        private void AppendIdAttribute(RenderTreeBuilder builder)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                builder.AddAttribute(1, "id", Id);
            }
        }

        private void AppendFeaturesAttributes(RenderTreeBuilder builder)
        {
            foreach (IEditorFeature item in _features)
            {
                item.AppendAttributes(2, builder);
            }
        }

        private void AppendFeaturesContent(RenderTreeBuilder builder)
        {
            builder.OpenRegion(3);
            foreach (IEditorFeature item in _features)
            {
                item.AppendContent(builder);
            }
            builder.CloseRegion();
        }

        private void AppendChildContent(RenderTreeBuilder builder)
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

        public T? AddFeature<T>() where T : class, IEditorFeature, new()
        {
            if (!_features.Any(c => c is T))
            {
                T feature = new();
                feature.OnSetup(this);
                _features.Add(feature);
                return feature;
            }
            return null;
        }

        public T? RemoveFeature<T>() where T : class, IEditorFeature, new()
        {
            T? feature = _features.FirstOrDefault(c => c is T) as T;
            if (feature != null)
            {
                _features.Remove(feature);
            }
            return feature;
        }

        public T? GetFeature<T>() where T : class, IEditorFeature, new()
        {
            return _features.FirstOrDefault(c => c is T) as T;
        }

        public T AddOrGetFeature<T>() where T : class, IEditorFeature, new()
        {
            if (!_features.Any(c => c is T))
            {
                T feature = new();
                feature.OnSetup(this);
                _features.Add(feature);
                return feature;
            }

            return (T)_features.First(c => c is T);
        }

        public bool HasFeature<T>() where T : class, IEditorFeature, new()
        {
            return _features.Any(c => c is T);
        }

        public IEditorWindow Refresh()
        {
            StateHasChanged();
            return this;
        }
    }
}