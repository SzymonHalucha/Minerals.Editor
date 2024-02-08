namespace Minerals.Editor.StateMachine.States
{
    public abstract class MouseEventBaseState<T> : StateMachineBase, IEditorState
        where T : IEditorEvent<MouseEventArgs>, new()
    {
        protected IEditorWindow? Source;
        protected Unit[] AnchorUnits = new Unit[4];

        public override IEditorState OnSetup(IEditorWindow target, IEditorArgs[]? args = null)
        {
            base.OnSetup(target, args);
            Source = GetEditorArgs<EditorArgsEventSource>(args)!.Source;
            return this;
        }

        public virtual IEditorState OnEnter(IEditorArgs[]? args = null)
        {
            AnchorUnits[0] = Target!.Anchor!.Units[0];
            AnchorUnits[1] = Target.Anchor.Units[1];
            AnchorUnits[2] = Target.Anchor.Units[2];
            AnchorUnits[3] = Target.Anchor.Units[3];
            Source!.GetFeature<EditorFeatureEvents>()!.SubscribeEvent<T, MouseEventArgs>(DoAction);
            Source.Refresh();
            return this;
        }

        public virtual IEditorState OnExit(IEditorArgs[]? args = null)
        {
            Source!.GetFeature<EditorFeatureEvents>()!.UnsubscribeEvent<T, MouseEventArgs>(DoAction);
            Source.Refresh();

            if (!HasEditorArgs<EditorArgsSaveTransform>(args))
            {
                Target!.Anchor!.Units[0] = AnchorUnits[0];
                Target.Anchor.Units[1] = AnchorUnits[1];
                Target.Anchor.Units[2] = AnchorUnits[2];
                Target.Anchor.Units[3] = AnchorUnits[3];
            }

            return this;
        }

        protected abstract void DoAction(MouseEventArgs args);
    }
}