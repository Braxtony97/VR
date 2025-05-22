using Interfaces;
using UI;

namespace Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;
        public Game(ICoroutineRunner coroutineRunner, UIManager uiManager)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), uiManager);    
        }
    }
}