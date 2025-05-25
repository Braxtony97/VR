using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.UI;

namespace Quests.Steps
{
    public class PushStep : Step
    {
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
            
            Debug.Log("Started Push Step");
        }

        private void ButtonPush()
        {
            _eventAggregator.Publish(new EventsProvider.PushButtonEvent());
            EndStep();
        }
        
        public override void EndStep()
        {
            Debug.Log("Ended Push Step");
            base.EndStep();
        }
        
        public override void Deinitialize()
        {
            base.Deinitialize();
            
            _confirmButton.onClick.RemoveListener(ButtonPush);
        }
    }
}