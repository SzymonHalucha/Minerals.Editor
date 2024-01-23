using Minerals.Editor.Builders;

namespace Minerals.Editor.Components
{
    public partial class DefaultWindow : WindowComponentBase
    {
        [Parameter] public IEditorWindow? Root { get; set; }

        protected override void OnWindowRef(IEditorWindow window)
        {
            WindowRef = new EditorWindowBuilder()
            .BuildForReference(window)
            .SetRoot(Root!)
            .SetParameters(Tag, Id, Title)
            .AddMoveFeature()
            .AddResizeFeature()
            .AddResizeHorizontalFeature()
            .AddResizeVerticalFeature()
            .AddCloseFeature()
            .Build();

            if (Class != null)
            {
                WindowRef.AddCssClass(Class);
            }

            WindowRef.Refresh();
        }
    }
}