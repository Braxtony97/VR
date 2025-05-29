using Infrastructure;
using Infrastructure.GameStates;
using Interfaces;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace UI.TrainingPanels
{
    public class ResultPanelUI : BaseTrainingPanelUI
    {
        [SerializeField] private Button _mainMenu;
        
        private const string Boot = "Boot";
        private const string MainMenu = "MainMenu";
        
        private SceneLoader _sceneLoader;
        private GameStateMachine _stateMachine;
        
        public override void Initialize(IServiceLocator serviceLocator)
        {
            base.Initialize(serviceLocator);
            
            _sceneLoader = _serviceLocator.Resolve<SceneLoader>();
            _stateMachine = _serviceLocator.Resolve<GameStateMachine>();
            _mainMenu.onClick.AddListener(OnMainMenuClicked);
        }

        private void OnMainMenuClicked()
        {
            _sceneLoader.Load(MainMenu, EnterMainMenuState);
        }

        private void EnterMainMenuState()
        {
            _stateMachine.Enter<MainMenuState, string>(MainMenu);
        }
    }
}