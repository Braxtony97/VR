using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.Serialization;

namespace Quests
{
    public class QuestsManager : MonoBehaviour  
    {
        public Group[] Groups => _groups;
        
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
        }

        private void GroupEnded(EventsProvider.GroupEndedEvent groupEndedEvent)
        {
            if (_currentGroupIndex >= _groups.Length)
                return;
            
            if (_groups[_currentGroupIndex].GroupStage == groupEndedEvent.GroupStage)
            {
                _currentGroupIndex++;
                
                if (_currentGroupIndex < _groups.Length)
                    StartCurrentGroup();
                else
                    EndQuest();
            }
        }

        private void EndQuest()
        {
            foreach (Group group in _groups)
            {
                group.Deinitialize();
            }
            
            _eventAggregator.Publish(new EventsProvider.QuestEndedEvent(this));
            _eventAggregator.Publish(new EventsProvider.QuestPanelActiveEvent(Enums.TrainingPanelUI.Result));
        }

        private void OnDestroy()
        {
            _eventAggregator.Unsubscribe<EventsProvider.GroupEndedEvent>(GroupEnded);
        }
    }
}