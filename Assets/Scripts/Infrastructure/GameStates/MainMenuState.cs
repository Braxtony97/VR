using Interfaces;
using UI;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class MainMenuState : IPayloadState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly UIRoot _uiRoot;

        public MainMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, UIRoot uiRoot)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiRoot = uiRoot;
        }

        public void Enter(string payload)
        {
            _uiRoot.LoadingScreen.Show();
            _sceneLoader.Load(payload, MainMenuSceneLoaded);
        }

        private void MainMenuSceneLoaded()
        {
            _uiRoot.LoadingScreen.Hide();
        }

        public void Exit()
        {
        }
    }
}