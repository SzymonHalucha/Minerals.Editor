namespace Minerals.Editor.Window
{
    public abstract class WindowComponentBase : ComponentBase, IWindowComponent
    {
        [CascadingParameter(Name = "Parent")] public IWindowComponent? Parent { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter] public string? Id { get; set; }
        [Parameter] public string? Title { get; set; }

        [Parameter] public string? Tag { get; set; }
        [Parameter] public string? Class { get; set; }

        [Parameter] public EditorPoint Position { get; set; } = new();
        [Parameter] public EditorPoint Size { get; set; } = new();

        public IEditorWindow? Window
        {
            get => _window;
            protected set => OnWindowParameterSet(value);
        }

        private IEditorWindow? _window;

        private void OnWindowParameterSet(IEditorWindow? window)
        {
            _window = window;
            OnWindowBuild();
        }

        protected abstract void OnWindowBuild();
    }
}