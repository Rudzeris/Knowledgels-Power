using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IExitable> _states;
        private IExitable _currentState;
        
        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new ()
            {
                [typeof(BootstrapState)] = new BootstrapState(this,sceneLoader)
            };
        }

        public void Enter<TState>() where TState : IExitable
        {
            ChangeState<TState>();

            (_currentState as IState)?.Enter();
        }

        public void Enter<TState, TParam>(TParam arg) where TState : IExitable
        {
            ChangeState<TState>();
            
            (_currentState as IStateParam<TParam>)?.Enter(arg);
        }

        private void ChangeState<TState>() where TState : IExitable
        {
            _currentState?.Exit();

            var state = _states[typeof(TState)];
            _currentState = state;
        }
    }
}