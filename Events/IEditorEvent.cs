namespace Minerals.Editor.Events
{
    public interface IEditorEvent<T> where T : notnull, new()
    {
        public string Name { get; }
        public void Raise(T args);
        public void Subscribe(Action<T> listener);
        public void Unsubscribe(Action<T> listener);
    }
}