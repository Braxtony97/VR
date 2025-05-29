using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.Serialization;

namespace Quests
{
    public abstract class Step : MonoBehaviour, IExecutableStep
    {
        public virtual string Description { get; set; }
        public Group GroupOwner => _groupOwner;
        public Enums.StepStage StepStage;
        public bool IsActiveStep = false;

        protected const string MainCamera = "MainCamera";
        protected IServiceLocator _serviceLocator;
        protected IEventAggregator _eventAggregator;
        
        private Group _groupOwner;

        public virtual void Initialize(IServiceLocator serviceLocator, Group group)
        {
            _serviceLocator = serviceLocator;
            _eventAggregator = _serviceLocator.Resolve<IEventAggregator>();
            _groupOwner = group;
        }

        public virtual void StartStep()
        {
            IsActiveStep = true;
            _eventAggregator.Publish(new EventsProvider.StepStartedEvent(this));
        }

        public virtual void EndStep()
        {
            IsActiveStep = false;
            _eventAggregator.Publish(new EventsProvider.StepEndedEvent(this, _groupOwner));
        }

        public virtual void Deinitialize()
        {
        }
    }
}