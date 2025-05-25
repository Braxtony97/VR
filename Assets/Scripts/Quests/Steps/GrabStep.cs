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

        public override void Initialize(IServiceLocator serviceLocator)
        {
            base.Initialize(serviceLocator);
            
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
            base.EndStep();
            
            Debug.Log("Ended Drag Step");
        }
    }
}