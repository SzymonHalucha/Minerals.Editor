namespace Minerals.Editor.Transitions
{
    public abstract class EditorTransitionMouseEventBase<T1, T2, T3> : IEditorTransition<T1, T2>
        where T1 : IEditorState, new()
        where T2 : IEditorState, new()
        where T3 : IEditorEvent<MouseEventArgs>, new()
    {
        protected IEditorWindow? Target;
        protected IEditorWindow? Source;
        protected IEditorArgs[]? ExitStateArgs;
        protected IEditorArgs[]? EnterStateArgs;
        protected Func<bool>? Condition;

        public virtual IEditorTransition OnSetup
        (
            IEditorWindow target,
            IEditorArgs[]? transitionArgs = null,
            IEditorArgs[]? exitStateArgs = null,
            IEditorArgs[]? enterStateArgs = null
        )
        {
            Target = target;
            ExitStateArgs = exitStateArgs;
            EnterStateArgs = enterStateArgs;
            var conditionArgs = transitionArgs?.FirstOrDefault(x => x is EditorArgsCondition);
            Condition = (conditionArgs as EditorArgsCondition)?.Condition;
            var sourceArgs = transitionArgs?.FirstOrDefault(x => x is EditorArgsEventSource);
            Source = (sourceArgs as EditorArgsEventSource)!.Window;
            Source.SubscribeMouseEvent<T3>(DoTransition);
            return this;
        }

        public virtual IEditorTransition OnDestroy(IEditorArgs[]? args = null)
        {
            Source!.UnsubscribeMouseEvent<T3>(DoTransition);
            return this;
        }

        public virtual IEditorWindow GetWindow()
        {
            return Target!;
        }

        protected virtual void DoTransition(MouseEventArgs args)
        {
            if (Target!.IsCurrentState<T1>() && (Condition == null || Condition.Invoke()))
            {
                Target!.ChangeState<T2>(ExitStateArgs, EnterStateArgs);
            }
        }
    }
}