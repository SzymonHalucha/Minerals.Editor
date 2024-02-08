namespace Minerals.Editor.Features
{
    public class EditorFeatureStyles : EditorFeatureBase
    {
        private readonly Dictionary<string, string> _styles = [];
        private readonly List<string> _classes = [];

        public override void AppendAttributes(int sequence, RenderTreeBuilder builder)
        {
            string styleText = Root!.Anchor!.Build();
            //FIX: Optimize this for allocation (EditorComponentStyles - SetAttributes)
            if (_styles.Count > 0)
            {
                foreach (var style in _styles)
                {
                    styleText += $"{style.Key}:{style.Value};";
                }
            }
            builder.AddAttribute(sequence, "style", styleText);

            //FIX: Optimize this for allocation (EditorComponentStyles - SetAttributes)
            if (_classes.Count > 0)
            {
                builder.AddAttribute(sequence, "class", string.Join(" ", _classes));
            }
        }

        public void AddClass(string className)
        {
            if (!_classes.Contains(className))
            {
                _classes.Add(className);
            }
        }

        public void RemoveClass(string className)
        {
            _classes.Remove(className);
        }

        public void AddStyle(string key, string value)
        {
            if (!_styles.TryAdd(key, value))
            {
                _styles[key] = value;
            }
        }

        public void RemoveStyle(string key)
        {
            _styles.Remove(key);
        }
    }
}