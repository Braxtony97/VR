using Interfaces;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class BootstrapState : IState
    {
        private readonly IServiceLocator _serviceLocator;
        private const string Boot = "Boot";
        private const string MainMenu = "MainMenu";
        
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            
            _sceneLoader = _serviceLocator.Resolve<SceneLoader>();
            _stateMachine = _serviceLocator.Resolve<GameStateMachine>();
        }

        public void Enter()
        {
            RegisterServices();
        }

        private void RegisterServices() => 
            _sceneLoader.Load(Boot, EnterMainMenuState);

        private void EnterMainMenuState() => 
            _stateMachine.Enter<MainMenuState, string>(MainMenu);


        public void Exit()
        {
        }
    }
}