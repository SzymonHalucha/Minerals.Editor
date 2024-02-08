namespace Minerals.Editor.StateMachine.States
{
    public class MoveState : MouseEventBaseState<EditorEventOnMouseMove>
    {
        public override IEditorState OnEnter(IEditorArgs[]? args = null)
        {
            base.OnEnter(args);
            if (HasEditorArgs<EditorArgsIgnoreEvents>(args))
            {
                Target!.GetFeature<EditorFeatureStyles>()!.AddStyle("pointer-events", "none");
            }
            return this;
        }

        public override IEditorState OnExit(IEditorArgs[]? args = null)
        {
            base.OnExit(args);
            Target!.GetFeature<EditorFeatureStyles>()!.AddStyle("pointer-events", "all");
            return this;
        }

        protected override void DoAction(MouseEventArgs args)
        {
            Target!.Anchor!.AddDeltaPosition(args.MovementX, args.MovementY);
            Target.Parent!.Refresh();
        }
    }
}