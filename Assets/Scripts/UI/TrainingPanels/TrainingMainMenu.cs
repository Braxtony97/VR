using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.UI;

namespace UI.TrainingPanels
{
    public class TrainingMainMenu : BaseTrainingPanelUI
    {
        [SerializeField] private Button _instructionPanelButton;

        public override void Initialize(IServiceLocator serviceLocator)
        {
            base.Initialize(serviceLocator); 
            
            _instructionPanelButton.onClick.AddListener(() => _eventAggregator.Publish(new EventsProvider.QuestPanelActiveEvent(Enums.TrainingPanelUI.Instruction)));
        }
    }
}