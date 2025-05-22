using Interfaces;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class BootstrapState : IState
    {
        private const string Boot = "Boot";
        private const string MainMenu = "MainMenu";
        
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            _sceneLoader.Load(Boot, EnterMainMenuState);
        }

        private void EnterMainMenuState()
        {
            _stateMachine.Enter<MainMenuState, string>(MainMenu);
        }


        public void Exit()
        {
        }
    }
}