using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine stateMachine;
        public static IInputService InputService;

        public Game()
        {
            stateMachine = new GameStateMachine();
        }
    }
}