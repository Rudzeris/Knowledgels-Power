using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _routineRunner;

        public SceneLoader(ICoroutineRunner routineRunner)
            => _routineRunner = routineRunner;

        public void Load(string sceneName, Action onLoaded = null)
            => _routineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            if (sceneName == SceneManager.GetActiveScene().name)
            {
                onLoaded?.Invoke();
                yield break;
            }

            var waitNextScene = SceneManager.LoadSceneAsync(sceneName);

            if (waitNextScene == null)
            {
                Debug.LogError($"Scene '{sceneName}' not found");
                yield break;
            }

            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}