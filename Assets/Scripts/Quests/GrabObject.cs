using Infrastructure;
using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Quests
{
    public class GrabObject : XRGrabInteractable
    {
        private const string TargetZone = "TargetZone";

        private Collider _targetZone;
        private bool _wasGrabbed;
        private IServiceLocator _serviceLocator;
        private IEventAggregator _eventAggregator;

        public void Initialize(IServiceLocator serviceLocator, Collider targetZone)
        {
            _serviceLocator = serviceLocator;
            _targetZone = targetZone;
            
            _eventAggregator = _serviceLocator.Resolve<IEventAggregator>();
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);
            _wasGrabbed = true;
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);

            _wasGrabbed = false;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == TargetZone && !_wasGrabbed)
                _eventAggregator.Publish(new EventsProvider.ObjectDropZoneEvent(true));
        }
    }
}