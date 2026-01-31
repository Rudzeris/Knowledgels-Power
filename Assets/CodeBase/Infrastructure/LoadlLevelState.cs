using CodeBase.CameraLogic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure
{
    public class LoadlLevelState : IStateParam<string>
    {
        private const string Initialpoint = "InitialPoint";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadlLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            var initialPoint = GameObject.FindGameObjectWithTag(Initialpoint);

            var hero = Instantiate("Hero/hero", initialPoint.transform.position);
            CameraFollow(hero);

            Instantiate("HUD/Hud");
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        private void CameraFollow(GameObject target)
            => Camera.main.GetComponent<CameraFollow>().Follow(target);
    }
}