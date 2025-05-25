using Interfaces;
using Static;
using UnityEngine;

namespace Quests
{
    public abstract class Step : MonoBehaviour, IExecutableStep
    {
        public Enums.StepStage StepStage;
        
        protected IServiceLocator _serviceLocator;
        protected IEventAggregator _eventAggregator;
        
        public virtual void Initialize(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            
            _eventAggregator = _serviceLocator.Resolve<IEventAggregator>();
        }

        public virtual void StartStep()
        {
            _eventAggregator.Publish(new EventsProvider.StepStartedEvent(this));
        }

        public virtual void EndStep()
        {
            _eventAggregator.Publish(new EventsProvider.StepEndedEvent(this));
        }

        public virtual void Deinitialize()
        {
        }
    }
}