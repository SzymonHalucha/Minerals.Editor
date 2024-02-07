namespace Minerals.Editor.Components
{
    public class EditorComponentThemes : EditorComponentBase
    {
        private IEditorThemes? _themes;

        public override void AppendAttributes(int sequence, RenderTreeBuilder builder)
        {
            if (_themes != null && _themes.Active != ThemePackage.Empty)
            {
                builder.AddAttribute(sequence, _themes.Active.Id);
            }
        }

        public void AppendEditorThemes(IEditorThemes themes)
        {
            _themes = themes;
        }

        public IEditorThemes? GetEditorThemes()
        {
            return _themes;
        }
    }
}