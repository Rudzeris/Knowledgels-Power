using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        
        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
        }

        private void RegisterServices()
        {
            Game.InputService = SetupInputService();
        }

        public void Exit()
        {
        }

        private static IInputService SetupInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
            {
                return new MobileInputService();
            }
        }
    }
}