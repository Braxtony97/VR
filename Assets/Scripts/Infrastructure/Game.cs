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
            serviceLocator.Register(sceneLoader);
            
            StateMachine = new GameStateMachine(serviceLocator);
            
            serviceLocator.Register(StateMachine);
            
            StateMachine.Init();
        }
    }
}