namespace Minerals.Editor.Components
{
    public abstract class WindowComponentBase : ComponentBase
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter] public string? Tag { get; set; }
        [Parameter] public string? Id { get; set; }
        [Parameter] public string? Class { get; set; }
        [Parameter] public string? Title { get; set; }

        public IEditorWindow? Window
        {
            get => WindowRef;
            protected set => OnWindowRef(value!);
        }

        protected IEditorWindow? WindowRef;

        protected abstract void OnWindowRef(IEditorWindow window);
    }
}