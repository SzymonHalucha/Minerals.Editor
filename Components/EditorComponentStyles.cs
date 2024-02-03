using System.Reflection.Metadata;

namespace Minerals.Editor.Components
{
    public class EditorComponentStyles : EditorComponentBase
    {
        private readonly List<string> _classes = [];
        private readonly Dictionary<string, string> _styles = [];

        //FIX: Optimize this for allocation (EditorComponentStyles - SetAttributes)
        public override void SetAttributes(int sequence, RenderTreeBuilder builder)
        {
            HandleTransform();

            if (_styles.Count > 0)
            {
                string text = "";
                foreach (var style in _styles)
                {
                    text += $"{style.Key}:{style.Value};";
                }
                builder.AddAttribute(sequence, "style", text);
            }

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

        //FIX: Optimize this for allocation (EditorComponentStyles - HandleTransform)
        private void HandleTransform()
        {
            string x = $"{Root!.Transform.Position.X}{Root!.Transform.Position.XUnit.UnitToString()}";
            string y = $"{Root!.Transform.Position.Y}{Root!.Transform.Position.YUnit.UnitToString()}";
            if (Root!.Transform.Anchor.HasFlag(EditorAnchor.Left))
            {
                AddStyle("left", x);
            }
            if (Root!.Transform.Anchor.HasFlag(EditorAnchor.Right))
            {
                AddStyle("right", x);
            }
            if (Root!.Transform.Anchor.HasFlag(EditorAnchor.Top))
            {
                AddStyle("top", y);
            }
            if (Root!.Transform.Anchor.HasFlag(EditorAnchor.Bottom))
            {
                AddStyle("bottom", y);
            }

            string width = $"{Root!.Transform.Size.X}{Root!.Transform.Size.XUnit.UnitToString()}";
            string height = $"{Root!.Transform.Size.Y}{Root!.Transform.Size.YUnit.UnitToString()}";
            AddStyle("width", width);
            AddStyle("height", height);
        }
    }
}