using System.Collections.Generic;
using Infrastructure;
using Interfaces;
using Quests;
using Static;
using UnityEngine;
using UnityEngine.UI;

namespace UI.TrainingPanels
{
    public class InstructionPanelUI : BaseTrainingPanelUI
    {
        [SerializeField] private GroupUI _groupUIPrefab;
        [SerializeField] private GroupPanelUI _groupPanelUI;
        
        private List<GroupUI> _groupUIList = new();
        private Group _currentActiveGroup;
        
        public override void Initialize(IServiceLocator serviceLocator)
        {
            base.Initialize(serviceLocator);  

            for (var i = 0; i < PlayModeSceneManager.Instance.QuestManager.Groups.Length; i++)
            {
                var group = PlayModeSceneManager.Instance.QuestManager.Groups[i];
                var groupUI = Instantiate(_groupUIPrefab, _container);
                groupUI.SetGroup(group);
                
                groupUI.SetGroupName(group.name);
                
                Button groupUIButton = groupUI.GetComponent<Button>();
                groupUIButton.onClick.AddListener(() => OpenGroupPanelUI(group));
                
                _groupUIList.Add(groupUI);
                
                _eventAggregator.Subscribe<EventsProvider.GroupStartEvent>(GroupStartEvent);
            }
        }
        
        private void OpenGroupPanelUI(Group questManagerGroup)
        {
            _groupPanelUI.SetStepsPanel(questManagerGroup);
            _eventAggregator.Publish(new EventsProvider.QuestPanelActiveEvent(Enums.TrainingPanelUI.Group));

            if (questManagerGroup.IsGroupActive)
            {
                _currentActiveGroup = questManagerGroup;
                UpdateActiveGroupUI();   
            }
        }

        private void GroupStartEvent(EventsProvider.GroupStartEvent groupStartEvent)
        {
            if (groupStartEvent.Group.IsGroupActive)
            {
                _currentActiveGroup = groupStartEvent.Group;
                UpdateActiveGroupUI(); 
            }
        }

        private void UpdateActiveGroupUI()
        {
            foreach (var groupUI in _groupUIList)
            {
                groupUI.SetActiveState(groupUI.Group == _currentActiveGroup);
            }
        }

        public override void Deinitialize()
        {
            base.Deinitialize();
            
            foreach (var groupUI in _groupUIList)
            {
                if (groupUI.TryGetComponent<Button>(out var button)) 
                    button.onClick.RemoveAllListeners();
            }
    
            _groupUIList.Clear();
            
            _eventAggregator.Unsubscribe<EventsProvider.GroupStartEvent>(GroupStartEvent);
        }
    }
}