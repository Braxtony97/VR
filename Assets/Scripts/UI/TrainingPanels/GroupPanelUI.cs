using System.Collections.Generic;
using Interfaces;
using Quests;
using Static;
using Unity.VisualScripting;
using UnityEngine;

namespace UI.TrainingPanels
{
    public class GroupPanelUI : BaseTrainingPanelUI
    {
        [SerializeField] private StepUI _stepUIPrefab;
        
        private readonly List<StepUI> _stepUIPool = new();
        private Step _currentActiveStep;
        
        public override void Initialize(IServiceLocator serviceLocator)
        {
            base.Initialize(serviceLocator);
            
            _eventAggregator.Subscribe<EventsProvider.StepStartedEvent>(StepStartEvent);
        }
        

        public void SetStepsPanel(Group group)
        {
            foreach (var stepUI in _stepUIPool) 
                stepUI.gameObject.SetActive(false);

            for (int i = 0; i < group.Steps.Length; i++)
            {
                StepUI stepUI;
                
                if (i < _stepUIPool.Count)
                    stepUI = _stepUIPool[i];
                else
                {
                    stepUI = Instantiate(_stepUIPrefab, _container.transform);
                    _stepUIPool.Add(stepUI);
                }
                
                stepUI.gameObject.SetActive(true);
                stepUI.SetStepName(group.Steps[i].Description);
                stepUI.SetStep(group.Steps[i]);
                
                if (group.Steps[i].IsActiveStep)
                    _currentActiveStep = group.Steps[i]; 
            }
            
            UpdateActiveStepUI();
        }
        
        private void StepStartEvent(EventsProvider.StepStartedEvent stepStartedEvent)
        {
            if (stepStartedEvent.Step.IsActiveStep)
            {
                _currentActiveStep = stepStartedEvent.Step; 
                UpdateActiveStepUI();
            }
        }
        
        private void UpdateActiveStepUI()
        {
            foreach (var stepUI in _stepUIPool)
            {
                stepUI.SetActiveStep(stepUI.Step == _currentActiveStep);
            }
        }

        public override void Deinitialize()
        {
            base.Deinitialize();
            
            _stepUIPool.Clear();
            
            _eventAggregator.Unsubscribe<EventsProvider.StepStartedEvent>(StepStartEvent);
        }
    }
}