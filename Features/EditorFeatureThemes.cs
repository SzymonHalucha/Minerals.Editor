namespace Minerals.Editor.Features
{
    public class EditorFeatureThemes : EditorFeatureBase
    {
        public IEditorThemes? EditorThemes { get; set; }

        public override void AppendAttributes(int sequence, RenderTreeBuilder builder)
        {
            if (EditorThemes != null && EditorThemes.Active != ThemePackage.Empty)
            {
                builder.AddAttribute(sequence, EditorThemes.Active.Id);
            }
        }
    }
}