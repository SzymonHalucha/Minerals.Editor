namespace Minerals.Editor.Events
{
    public interface IEditorEvent
    {
        public string Name { get; }
        public void AddEventToAttribute(int sequence, RenderTreeBuilder builder);
    }

    public interface IEditorEvent<T> : IEditorEvent where T : notnull, new()
    {
        public void Raise(T args);
        public void Subscribe(Action<T> listener);
        public void Unsubscribe(Action<T> listener);
    }
}