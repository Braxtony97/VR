using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GroupPanelUI : BaseTrainingPanelUI
    {
        [SerializeField] private StepUI _stepUIPrefab;
        
        public override void Initialize(IServiceLocator serviceLocator)
        {
            base.Initialize(serviceLocator);
            
            for (int i = 0; i < 3; i++)
            {
                var stepUI = Instantiate(_stepUIPrefab, _container.transform);
                stepUI.GetComponent<Button>().onClick.AddListener(OpenGroupPanel);
            }
        }

        private void OpenGroupPanel()
        {
            _eventAggregator.Publish(new EventsProvider.QuestPanelActiveEvent(Enums.TrainingPanelUI.Step));
        }
    }
}