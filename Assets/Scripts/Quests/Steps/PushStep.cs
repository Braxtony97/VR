using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.UI;

namespace Quests.Steps
{
    public class PushStep : Step
    {
        public override string Description { get; set; } = "Нажмите на желтую кнопку";
        
        [Header("Stage Parameters\n")]
        [SerializeField] private Button _confirmButton;
        
        public override void Initialize(IServiceLocator serviceLocator, Group group)
        {
            base.Initialize(serviceLocator, group);
            
            _confirmButton.onClick.AddListener(ButtonPush);
        }

        public override void StartStep()
        {
            base.StartStep();
        }

        private void ButtonPush()
        {
            _eventAggregator.Publish(new EventsProvider.PushButtonEvent());
            EndStep();
        }
        
        public override void EndStep()
        {
            base.EndStep();
        }
        
        public override void Deinitialize()
        {
            base.Deinitialize();
            
            _confirmButton.onClick.RemoveListener(ButtonPush);
        }
    }
}