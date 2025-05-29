using Infrastructure;
using Infrastructure.GameStates;
using Interfaces;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class MainMenuScreen : ScreenView
    {
        [Header("\nUI Elements")]
        [SerializeField] private Button _trainingScene;
        [SerializeField] private Button _exitButton;

        private const string Training = "Training";

        public override void Initialize(IEventAggregator eventAggregator, IServiceLocator serviceLocator, Camera camera)
        {
            base.Initialize(eventAggregator, serviceLocator, camera);
            
            _trainingScene.onClick.AddListener(ClickTrainingButton); 
            _exitButton.onClick.AddListener(QuitApplication);
        }

        private void ClickTrainingButton()
        {
            _serviceLocator.Resolve<GameStateMachine>().Enter<TrainingState, string>(Training);
        } 
        
        private void QuitApplication()
        {
            Application.Quit();

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }

        public override void Deinitialize()
        {
            _trainingScene.onClick.RemoveListener(ClickTrainingButton); 
            _exitButton.onClick.RemoveListener(QuitApplication);
        }
    }
}