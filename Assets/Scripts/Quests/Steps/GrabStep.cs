using Interfaces;
using Static;
using UnityEngine;

namespace Quests.Steps
{
    public class GrabStep : Step
    {
        public override string Description { get; set; } = "Перенести красную коробку в прозрачную область";
        
        [Header("Stage Parameters\n")]
        [SerializeField] private GrabObject _grabObject;
        [SerializeField] private Collider _targetZone;

        public override void Initialize(IServiceLocator serviceLocator, Group group)
        {
            base.Initialize(serviceLocator, group);
            
            _grabObject.Initialize(serviceLocator, _targetZone);
            
            _eventAggregator.Subscribe<EventsProvider.ObjectDropZoneEvent>(ObjectDropped);
        }

        private void ObjectDropped(EventsProvider.ObjectDropZoneEvent objectDropZoneEvent)
        {
            if (objectDropZoneEvent.IsObjectDropZone)
                EndStep();
        }

        public override void StartStep()
        {
            base.StartStep();
        }
        
        public override void EndStep()
        {
            base.EndStep();
        }
        
        public override void Deinitialize()
        {
            base.Deinitialize();
            
            _eventAggregator?.Unsubscribe<EventsProvider.ObjectDropZoneEvent>(ObjectDropped);
        }
    }
}