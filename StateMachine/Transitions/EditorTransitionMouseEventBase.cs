namespace Minerals.Editor.StateMachine.Transitions
{
    public abstract class EditorTransitionMouseEventBase<T1, T2, T3> : EditorStateMachineBase, IEditorTransition<T1, T2>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new()
        where T3 : IEditorEvent<MouseEventArgs>, new()
    {
        protected IEditorWindow? Source;
        protected IEditorArgs[]? ExitStateArgs;
        protected IEditorArgs[]? EnterStateArgs;
        protected Func<bool>? Condition;

        public override IEditorStateMachine OnSetup(IEditorWindow target, IEditorArgs[]? args = null)
        {
            base.OnSetup(target, args);
            Condition = GetEditorArgs<EditorArgsCondition>(args)?.Condition;
            Source = GetEditorArgs<EditorArgsEventSource>(args)!.Source!;
            Source!.GetComponent<EditorComponentEvents>()!.SubscribeEvent<T3, MouseEventArgs>(DoTransition);
            return this;
        }

        public override IEditorStateMachine OnDestroy()
        {
            base.OnDestroy();
            Source!.GetComponent<EditorComponentEvents>()!.UnsubscribeEvent<T3, MouseEventArgs>(DoTransition);
            return this;
        }

        public IEditorTransition SetAdditionalArgs(IEditorArgs[]? exitStateArgs = null, IEditorArgs[]? enterStateArgs = null)
        {
            ExitStateArgs = exitStateArgs;
            EnterStateArgs = enterStateArgs;
            return this;
        }

        protected void DoTransition(MouseEventArgs args)
        {
            if (Condition == null || Condition.Invoke())
            {
                Target!.GetComponent<EditorComponentStates>()!.ChangeState<T1, T2>(ExitStateArgs, EnterStateArgs);
            }
        }
    }
}