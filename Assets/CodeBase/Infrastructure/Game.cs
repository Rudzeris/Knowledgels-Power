using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine stateMachine;
        public static IInputService InputService;

        public Game(ICoroutineRunner coroutineRunner)
        {
            stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}