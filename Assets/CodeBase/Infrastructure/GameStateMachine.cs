using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitable> _states;
        private IExitable _currentState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadlLevelState)] = new LoadlLevelState(this, sceneLoader)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            ChangeState<TState>()?.Enter();
        }

        public void Enter<TState, TParam>(TParam arg) where TState : class, IStateParam<TParam>
        {
            ChangeState<TState>()?.Enter(arg);
        }

        private TState ChangeState<TState>() where TState : class, IExitable
        {
            _currentState?.Exit();

            var state = GetState<TState>();
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitable => _states[typeof(TState)] as TState;
    }
}