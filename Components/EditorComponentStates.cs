namespace Minerals.Editor.Components
{
    public class EditorComponentStates : EditorComponentBase
    {
        private readonly List<IEditorState> _states = [];
        private readonly List<IEditorTransition> _transitions = [];
        private IEditorState? _currentState;

        public IEditorState? AddState<T>(IEditorArgs[]? stateArgs = null)
            where T : IEditorState, new()
        {
            if (!HasState<T>())
            {
                T state = new();
                state.OnSetup(Root!, stateArgs);
                _states.Add(state);
                return state;
            }
            return null;
        }

        public bool ChangeState<T1, T2>
        (
            IEditorArgs[]? exitStateArgs = null,
            IEditorArgs[]? enterStateArgs = null
        ) where T1 : IEditorState, new() where T2 : IEditorState, new()
        {
            if (_currentState is T1 || _currentState == null)
            {
                _currentState?.OnExit(exitStateArgs);
                _currentState = _states.First(x => x is T2);
                _currentState.OnEnter(enterStateArgs);
                (Root!.Parent ?? Root)!.Refresh();
                return true;
            }
            return false;
        }

        public bool HasState<T>() where T : IEditorState, new()
        {
            return _states.Any(x => x is T);
        }

        public IEditorTransition AddTransition<T>
        (
            IEditorArgs[]? transitionArgs = null,
            IEditorArgs[]? exitStateArgs = null,
            IEditorArgs[]? enterStateArgs = null
        ) where T : IEditorTransition, new()
        {
            T transition = new();
            transition.OnSetup(Root!, transitionArgs);
            transition.SetAdditionalArgs(exitStateArgs, enterStateArgs);
            _transitions.Add(transition);
            return transition;
        }
    }
}