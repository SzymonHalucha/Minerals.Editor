namespace Minerals.Editor.Features
{
    public class EditorFeatureEvents : EditorFeatureBase
    {
        private readonly Dictionary<Type, List<IEditorEvent>> _events = [];

        public override void AppendAttributes(int sequence, RenderTreeBuilder builder)
        {
            if (_events.Count > 0)
            {
                foreach (List<IEditorEvent> list in _events.Values)
                {
                    if (list.Count > 0)
                    {
                        foreach (IEditorEvent evt in list)
                        {
                            evt.AddEventToAttribute(sequence, builder);
                        }
                    }
                }
            }
        }

        public void SubscribeEvent<T1, T2>(Action<T2> action)
            where T1 : IEditorEvent<T2>, new()
            where T2 : notnull, new()
        {
            Type type = typeof(T2);
            if (!_events.ContainsKey(type))
            {
                _events.Add(type, []);
            }
            var evt = _events[type].FirstOrDefault(x => x is T1);
            if (evt == null)
            {
                evt = new T1();
                _events[type].Add(evt);
            }
            ((T1)evt).Subscribe(action);
        }

        public void UnsubscribeEvent<T1, T2>(Action<T2> action)
            where T1 : IEditorEvent<T2>, new()
            where T2 : notnull, new()
        {
            var evt = _events[typeof(T2)].First(x => x is T1);
            ((T1)evt).Unsubscribe(action);
        }
    }
}