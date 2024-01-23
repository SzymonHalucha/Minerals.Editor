using Minerals.Editor.Builders;

namespace Minerals.Editor.Components
{
    public partial class RootWindow : WindowComponentBase
    {
        protected override void OnWindowRef(IEditorWindow window)
        {
            WindowRef = new EditorWindowBuilder()
            .BuildForReference(window)
            .SetParameters(Tag, Id, Title)
            .Build();

            if (Class != null)
            {
                WindowRef.AddCssClass(Class);
            }

            WindowRef.Refresh();
        }
    }
}