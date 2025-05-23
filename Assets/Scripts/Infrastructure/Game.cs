using Interfaces;
using UI;

namespace Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;
        public Game(IServiceLocator serviceLocator)
        {
            SceneLoader sceneLoader = new SceneLoader(serviceLocator.Resolve<ICoroutineRunner>());  
            StateMachine = new GameStateMachine(serviceLocator);
            
            serviceLocator.Register(sceneLoader);
            serviceLocator.Register(StateMachine);
            
            StateMachine.Init();
        }
    }
}