namespace Minerals.Editor.Components
{
    public partial class DefaultComponent : EditorComponentBase
    {
        [Parameter] public bool IsMovable { get; set; }
        [Parameter] public bool IsClosable { get; set; }
        [Parameter] public bool IsResizable { get; set; }
        [Parameter] public bool IsVerticalResizable { get; set; }
        [Parameter] public bool IsHorizontalResizable { get; set; }
        [Parameter] public bool IsSnappable { get; set; }
        [Parameter] public bool IsScrollable { get; set; }

        protected override void OnComponentBuild()
        {
            var builder = new EditorWindowBuilder()
                .BuildForReference(Window!)
                .SetId(Id)
                .SetTag(Tag)
                .SetParent(Parent?.Window ?? ParentInherited?.Window)
                .SetAnchor(Anchor)
                .AddFeature<EditorFeatureStyles>(out _)
                .AddFeature<EditorFeatureEvents>(out _)
                .AddFeature<EditorFeatureStates>(out _)
                .AddClasses(ThemeSelectors.DefaultWindow)
                .AddClasses(Class)
                .AddDefaultStyle()
                .AddDefaultState();

            EditorWindowDirector director = new();

            if (IsThemable)
            {
                builder.AddFeature<EditorFeatureThemes>(out _);
                builder.SetEditorThemes(Themes ?? ThemesInherited);
            }

            if (IsMovable)
            {
                EditorWindow cmp = director.BuildHeaderWindow(Window);
                builder.AddMoveState(cmp);
            }

            if (IsClosable)
            {
                EditorWindow cmp = director.BuildCloseWindow(Window);
                builder.AddCloseState(cmp);
            }

            if (IsResizable)
            {
                EditorWindow cmp = director.BuildResizeWindow(Window);
                builder.AddResizeState(cmp);
            }

            if (IsVerticalResizable)
            {
                EditorWindow cmp = director.BuildVerticalResizeWindow(Window);
                builder.AddVerticalResizeState(cmp);
            }

            if (IsHorizontalResizable)
            {
                EditorWindow cmp = director.BuildHorizontalResizeWindow(Window);
                builder.AddHorizontalResizeState(cmp);
            }

            if (IsSnappable)
            {
                builder.AddSnapState();
            }

            if (IsScrollable)
            {
                builder.AddScrollState();
            }

            builder.Build();
        }
    }
}