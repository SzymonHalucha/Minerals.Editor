namespace Minerals.Editor.Events
{
    public abstract class EditorEventBase<T> : IEditorEvent<T>
        where T : notnull, new()
    {
        public abstract string Name { get; }
        private event Action<T>? Action;

        public virtual void Raise(T args)
        {
            Action?.Invoke(args);
        }

        public virtual void Subscribe(Action<T> listener)
        {
            Action += listener;
        }

        public virtual void Unsubscribe(Action<T> listener)
        {
            Action -= listener;
        }
    }
}