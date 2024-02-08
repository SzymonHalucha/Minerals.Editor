namespace Minerals.Editor.Components
{
    public abstract class EditorComponentBase : ComponentBase, IEditorComponent
    {
        [CascadingParameter(Name = "Parent")] public IEditorComponent? ParentInherited { get; set; }
        [CascadingParameter(Name = "Themes")] public IEditorThemes? ThemesInherited { get; set; }

        [Parameter] public IEditorComponent? Parent { get; set; }
        [Parameter] public IEditorThemes? Themes { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter] public string? Id { get; set; }
        [Parameter] public string? Title { get; set; }

        [Parameter] public string? Tag { get; set; }
        [Parameter] public string? Class { get; set; }

        [Parameter] public bool IsThemable { get; set; } = true;

        [Parameter] public IEditorAnchor? Anchor { get; set; }

        public IEditorWindow? Window
        {
            get => _window;
            protected set => OnWindowParameterSet(value);
        }

        private IEditorWindow? _window;

        private void OnWindowParameterSet(IEditorWindow? window)
        {
            _window = window;
            OnComponentBuild();
        }

        protected abstract void OnComponentBuild();
    }
}