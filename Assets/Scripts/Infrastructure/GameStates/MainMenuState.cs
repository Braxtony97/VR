using Interfaces;
using Static;
using UI;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class MainMenuState : IPayloadState<string>
    {
        private readonly IServiceLocator _serviceLocator;
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UIManager _uiManager;

        public MainMenuState(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _gameStateMachine = _serviceLocator.Resolve<GameStateMachine>();
            _sceneLoader = _serviceLocator.Resolve<SceneLoader>();
            _uiManager = _serviceLocator.Resolve<UIManager>();
        }
        
        public void Enter(string payload)
        {
            _uiManager.CreateScreen(Enums.ScreenType.LoadingScreen);
            _sceneLoader.Load(payload, MainMenuSceneLoaded);
        }

        private void MainMenuSceneLoaded()
        {
            _uiManager.CreateScreen(Enums.ScreenType.MainMenu);
        }

        public void Exit()
        {
        }
    }
}