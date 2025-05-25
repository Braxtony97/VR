using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.Serialization;

namespace Quests
{
    public class QuestsManager : MonoBehaviour  
    {
        [SerializeField] public Group[] _groups;
        
        private int _currentGroupIndex;
        private IEventAggregator _eventAggregator;

        public void Initialize(IServiceLocator serviceLocator)
        {
            _eventAggregator = serviceLocator.Resolve<IEventAggregator>();
            _eventAggregator.Subscribe<EventsProvider.GroupEndedEvent>(GroupEnded); 
            
            foreach (Group group in _groups)
            {
                group.Initialize(serviceLocator);
            }
        }
        
        public void StartQuest()
        {
            _currentGroupIndex = 0;
            StartCurrentGroup();
        }
        
        private void StartCurrentGroup()
        {
            if (_currentGroupIndex < _groups.Length)
                _groups[_currentGroupIndex].StartGroup();
            
            Debug.Log($"STARTING GROUP {_currentGroupIndex}");
        }

        private void GroupEnded(EventsProvider.GroupEndedEvent groupEndedEvent)
        {
            if (_currentGroupIndex >= _groups.Length)
                return;
            
            if (_groups[_currentGroupIndex].GroupStage == groupEndedEvent.GroupStage)
            {
                _currentGroupIndex++;
                
                Debug.Log("_currentGroupIndex " + _currentGroupIndex);

                Debug.Log("_groups.Length " + _groups.Length);
                
                if (_currentGroupIndex < _groups.Length)
                    StartCurrentGroup();
                else
                    EndQuest();
            }
        }

        private void EndQuest()
        {
            Debug.Log("Quest completed");
            
            foreach (Group group in _groups)
            {
                group.Deinitialize();
            }
            
            _eventAggregator.Publish(new EventsProvider.QuestEndedEvent(this));
        }
    }
}