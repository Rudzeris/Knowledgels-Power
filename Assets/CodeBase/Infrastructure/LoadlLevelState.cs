using CodeBase.CameraLogic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure
{
    public class LoadlLevelState : IStateParam<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadlLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName,OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            var hero = Instantiate("Hero/hero");
            CameraFollow(hero);
            Instantiate("HUD/Hud");
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private void CameraFollow(GameObject target) 
            => Camera.main.GetComponent<CameraFollow>().Follow(target);
    }
}