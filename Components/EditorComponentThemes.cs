namespace Minerals.Editor.Components
{
    public class EditorComponentThemes : EditorComponentBase
    {
        private IEditorThemes? _themes;

        public override void SetAttributes(int sequence, RenderTreeBuilder builder)
        {
            if (_themes != null && _themes.Active != null && _themes.Active != ThemePackage.Empty)
            {
                builder.AddAttribute(sequence, _themes.Active.Id);
            }
        }

        public void SetThemes(IEditorThemes themes)
        {
            _themes = themes;
        }
    }
}