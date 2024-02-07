namespace Minerals.Editor.Window
{
    public abstract class WindowComponentBase : ComponentBase, IWindowComponent
    {
        [CascadingParameter(Name = "Parent")] public IWindowComponent? Parent { get; set; }
        [CascadingParameter(Name = "Themes")] public IEditorThemes? ThemesInherited { get; set; }
        [Parameter] public IEditorThemes? Themes { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter] public string? Id { get; set; }
        [Parameter] public string? Title { get; set; }

        [Parameter] public string? Tag { get; set; }
        [Parameter] public string? Class { get; set; }

        [Parameter] public bool IsThemable { get; set; } = true;

        [Parameter] public EditorAnchor? Anchor { get; set; }
        [Parameter] public EditorUnit? Left { get; set; }
        [Parameter] public EditorUnit? Right { get; set; }
        [Parameter] public EditorUnit? Top { get; set; }
        [Parameter] public EditorUnit? Bottom { get; set; }
        [Parameter] public EditorUnit? Width { get; set; }
        [Parameter] public EditorUnit? Height { get; set; }

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