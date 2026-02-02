using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadlLevelState : IStateParam<string>
    {
        private const string Initialpoint = "InitialPoint";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _factory;

        public LoadlLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,
            LoadingCurtain curtain, IGameFactory factory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _factory = factory;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            var initialPoint = GameObject.FindGameObjectWithTag(Initialpoint);

            var hero = _factory.CreateHero(initialPoint.transform.position);
            CameraFollow(hero);

            _factory.CreateHud();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void CameraFollow(GameObject target)
            => Camera.main.GetComponent<CameraFollow>().Follow(target);
    }
}