namespace Minerals.Editor.StateMachine
{
    public abstract class StateMachineBase : IStateMachine
    {
        protected IEditorWindow? Target;

        public virtual IStateMachine OnSetup(IEditorWindow target, IEditorArgs[]? args = null)
        {
            Target = target;
            return this;
        }

        public virtual IStateMachine OnDestroy()
        {
            return this;
        }

        public virtual IEditorWindow GetWindow()
        {
            return Target!;
        }

        protected virtual bool HasEditorArgs<T>(IEditorArgs[]? args)
            where T : IEditorArgs, new()
        {
            return args?.Any(x => x is T) == true;
        }

        protected virtual T? GetEditorArgs<T>(IEditorArgs[]? args)
            where T : IEditorArgs, new()
        {
            var selected = args?.FirstOrDefault(x => x is T);
            return (T?)selected;
        }
    }
}