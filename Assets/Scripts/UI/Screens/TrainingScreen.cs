using Infrastructure;
using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class TrainingScreen : ScreenView
    {
        [Header("\nUI Elements")]
        [SerializeField] private Button _trainingScene;
        [SerializeField] private Button _exitButton;
        private IEventAggregator _eventAggregator;
        private IServiceLocator _serviceLocator;

        public override void Initialize(IEventAggregator eventAggregator, IServiceLocator serviceLocator)
        {
            _eventAggregator = eventAggregator;
            _serviceLocator = serviceLocator;
        }

        public override void Deinitialize()
        {
        }
    }
}