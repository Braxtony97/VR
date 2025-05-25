using Interfaces;
using Static;
using UnityEngine;

namespace Quests.Steps
{
    public class GrabStep : Step
    {
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
            
            Debug.Log("Started Drag Step");
        }
        
        public override void EndStep()
        {
            Debug.Log("Ended Drag Step");
            base.EndStep();
        }
        
        public override void Deinitialize()
        {
            base.Deinitialize();
            
            _eventAggregator?.Unsubscribe<EventsProvider.ObjectDropZoneEvent>(ObjectDropped);
        }
    }
}