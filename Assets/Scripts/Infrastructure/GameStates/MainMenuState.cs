using Interfaces;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class MainMenuState : IPayloadState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public MainMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, onLoaded: MainMenuSceneLoaded);
        }

        private void MainMenuSceneLoaded()
        {
            Debug.Log("Main menu scene loaded");
        }

        public void Exit()
        {
        }
    }
}