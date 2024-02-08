namespace Minerals.Editor.Builders
{
    public interface IEditorWindowDirector
    {
        public EditorWindow BuildHeaderWindow(IEditorWindow? parent);
        public EditorWindow BuildCloseWindow(IEditorWindow? parent);
        public EditorWindow BuildResizeWindow(IEditorWindow? parent);
        public EditorWindow BuildVerticalResizeWindow(IEditorWindow? parent);
        public EditorWindow BuildHorizontalResizeWindow(IEditorWindow? parent);
    }
}