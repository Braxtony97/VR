using Interfaces;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class BootstrapState : IState
    {
        private const string BOOT = "Boot";
        
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
            Debug.Log("Registering Services");
            
            _sceneLoader.Load(BOOT, EnterMainMenuState);
        }

        private void EnterMainMenuState()
        {
            _stateMachine.Enter<MainMenuState>();
        }


        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}