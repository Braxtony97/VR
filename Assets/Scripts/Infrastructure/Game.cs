using Interfaces;
using UI;

namespace Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;
        public Game(ICoroutineRunner coroutineRunner, UIRoot uiRoot)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), uiRoot);    
        }
    }
}