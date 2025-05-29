using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.Serialization;

namespace Quests
{
    public class Group : MonoBehaviour, IExecutableGroup
    {
        public Enums.GroupStage GroupStage;
        public bool IsGroupActive = false;
        public Step[] Steps => _steps;
        
        [SerializeField] private Step[] _steps;

        private int _currentStepIndex;
        private IServiceLocator _serviceLocator;
        private IEventAggregator _eventAggregator;

        public void Initialize(IServiceLocator serviceLocator)
        {
            _eventAggregator = serviceLocator.Resolve<IEventAggregator>();
            _eventAggregator?.Subscribe<EventsProvider.StepEndedEvent>(OnStepEnded);
            
            foreach (Step step in _steps)
            {
                step.Initialize(serviceLocator, this);
            }
        }
        
        public void StartGroup()
        {
            IsGroupActive = true;
            _eventAggregator.Publish(new EventsProvider.GroupStartEvent(this));
            _currentStepIndex = 0;
            StartCurrentStep();
        }

        private void StartCurrentStep()
        {
            if (_currentStepIndex < _steps.Length)
                _steps[_currentStepIndex].StartStep();

            IsGroupActive = true;
        }

        private void OnStepEnded(EventsProvider.StepEndedEvent stepEndedEvent)
        {
            if (_currentStepIndex >= _steps.Length)
                return;
            
            if (stepEndedEvent.GroupOwner != this)
                return;
            
            if (_steps[_currentStepIndex].StepStage == stepEndedEvent.StepStage)
            {
                _currentStepIndex++;
                
                if (_currentStepIndex < _steps.Length)
                    StartCurrentStep();
                else
                    EndGroup();
            }
        }

        public void EndGroup()
        {
            Deinitialize();
            IsGroupActive = false;
            _eventAggregator.Publish(new EventsProvider.GroupEndedEvent(this));
        }

        public void Deinitialize()
        {
            _eventAggregator?.Unsubscribe<EventsProvider.StepEndedEvent>(OnStepEnded);

            foreach (var step in _steps)
            {
                step.Deinitialize();
            }
        }
    }
}