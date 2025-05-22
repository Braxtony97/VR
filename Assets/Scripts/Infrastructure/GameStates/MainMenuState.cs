using Interfaces;
using UI;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class MainMenuState : IPayloadState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UIManager _uiManager;

        public MainMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, UIManager uiManager)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiManager = uiManager;
        }

        public void Enter(string payload)
        {
            _uiManager.ShowScreen(Enums.ScreenType.LoadingScreen);
            _sceneLoader.Load(payload, MainMenuSceneLoaded);
        }

        private void MainMenuSceneLoaded()
        {
            _uiManager.HideScreen(Enums.ScreenType.LoadingScreen);
            _uiManager.ShowScreen(Enums.ScreenType.MainMenu);
        }

        public void Exit()
        {
        }
    }
}