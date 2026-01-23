using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private static GameBootstrapper _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            _game = new Game(this);
            _game.stateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}