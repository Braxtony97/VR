using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InstructionPanelUI : BaseTrainingPanelUI
    {
        [SerializeField] private GroupUI _groupUIPrefab;
        [SerializeField] private GroupPanelUI _groupPanelUI;
        
        public override void Initialize(IServiceLocator serviceLocator)
        {
            base.Initialize(serviceLocator);  
            
            for (int i = 0; i < 3; i++)
            {
                var groupUI = Instantiate(_groupUIPrefab, _container);
                groupUI.GetComponent<Button>().onClick.AddListener(OpenGroupPanelUI);
            }
        }

        private void OpenGroupPanelUI()
        {
            _eventAggregator.Publish(new EventsProvider.QuestPanelActiveEvent(Enums.TrainingPanelUI.Group));
        }
    }
}