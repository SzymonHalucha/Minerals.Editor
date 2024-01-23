namespace Minerals.Editor
{
    public interface IEditorWindow
    {
        public RenderFragment? ChildContent { get; set; }

        public string Tag { get; set; }
        public string? Id { get; set; }
        public string? Class { get; set; }
        public string? Title { get; set; }

        public IEditorWindow? Root { get; set; }
        public IEditorWindow? Parent { get; set; }

        public Point2D Position { get; set; }
        public Point2D Size { get; set; }
        public bool Enabled { get; set; }

        public IEditorWindow SetTag(string tag);
        public IEditorWindow SetId(string id);
        public IEditorWindow SetTitle(string title);
        public IEditorWindow SetChildContent(Action<RenderTreeBuilder> builder);
        public RenderFragment GetContent();
        public IEditorWindow Refresh();

        public IEditorWindow SetCssStyle(string property, string value);
        public IEditorWindow AddCssClass(string name);
        public IEditorWindow RemoveCssClass(string name);

        public IEditorWindow AddChildWindow(IEditorWindow child);
        public IEditorWindow RemoveChildWindow(IEditorWindow child);
        public IEditorWindow SetParent(IEditorWindow? parent);
        public IEditorWindow SetRoot(IEditorWindow root);

        public IEditorWindow AddState<T>(IEditorArgs[]? stateArgs = null)
            where T : IEditorState, new();

        public IEditorWindow ChangeState<T>
        (
            IEditorArgs[]? exitStateArgs = null,
            IEditorArgs[]? enterStateArgs = null
        ) where T : IEditorState, new();

        public bool IsCurrentState<T>()
            where T : IEditorState, new();

        public bool HasState<T>()
            where T : IEditorState, new();

        public IEditorWindow AddTransition<T>
        (
            IEditorArgs[]? transitionArgs = null,
            IEditorArgs[]? exitStateArgs = null,
            IEditorArgs[]? enterStateArgs = null
        ) where T : IEditorTransition, new();

        public IEditorWindow SubscribeMouseEvent<T>(Action<MouseEventArgs> action)
            where T : IEditorEvent<MouseEventArgs>, new();

        public IEditorWindow UnsubscribeMouseEvent<T>(Action<MouseEventArgs> action)
            where T : IEditorEvent<MouseEventArgs>, new();
    }
}