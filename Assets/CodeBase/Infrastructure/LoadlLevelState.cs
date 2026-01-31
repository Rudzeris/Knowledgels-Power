using CodeBase.CameraLogic;
using CodeBase.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure
{
    public class LoadlLevelState : IStateParam<string>
    {
        private const string Initialpoint = "InitialPoint";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public LoadlLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,
            LoadingCurtain curtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
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

            var hero = Instantiate("Hero/hero", initialPoint.transform.position);
            CameraFollow(hero);

            Instantiate("HUD/Hud");
            
            _gameStateMachine.Enter<GameLoopState>();
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