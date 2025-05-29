using System.Collections.Generic;
using Interfaces;
using Static;
using UI.TrainingPanels;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class TrainingScreen : ScreenView
    {
        [Header("Main buttons")]
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _closeButton;
        
        [Header("Panels")] 
        [SerializeField] private BaseTrainingPanelUI[] _panels;
        
        private Stack<BaseTrainingPanelUI> _panelStack;
        

        public override void Initialize(IEventAggregator eventAggregator, IServiceLocator serviceLocator, Camera camera)
        {
            base.Initialize(eventAggregator, serviceLocator, camera);
            
            _closeButton.onClick.AddListener(() => Hide());
            _backButton.onClick.AddListener(BackMove);

            foreach (var panel in _panels) 
                panel.Initialize(_serviceLocator);
            
            _eventAggregator.Subscribe<EventsProvider.ShowHideScreenEvent>(ShowHideScreen);
            _eventAggregator.Subscribe<EventsProvider.QuestPanelActiveEvent>(ActivePanel);
            _eventAggregator.Subscribe<EventsProvider.TrainingPanelHideEvent>(ShowHidePanel);
            
            _panelStack = new Stack<BaseTrainingPanelUI>();
            
            ActivePanel(Enums.TrainingPanelUI.MainMenu);
        }

        private void ShowHidePanel(EventsProvider.TrainingPanelHideEvent trainingPanelHideEvent)
        {
            gameObject.SetActive(!trainingPanelHideEvent.IsShowing);
        }

        private void BackMove()
        {
            if (_panelStack.Count == 1)
                return;
            
            if (_panelStack.Count > 0)
            {
                var currentPanel = _panelStack.Pop();
                currentPanel.Deactivate();
            }

            if (_panelStack.Count > 0)
            {
                var previousPanel = _panelStack.Peek();
                previousPanel.Activate();
            }
        }

        private void ActivePanel(EventsProvider.QuestPanelActiveEvent questPanelActiveEvent)
        {
            ActivePanel(questPanelActiveEvent.Panel);
        }

        private void ActivePanel(Enums.TrainingPanelUI trainingPanelUI)
        {
            if (trainingPanelUI == null || _panels == null) 
                return;
            
            foreach (var panel in _panels)
            {
                if (panel.TrainingPanelUI == trainingPanelUI)
                {
                    panel.Activate();
                    
                    if (_panelStack.Count == 0 || _panelStack.Peek() != panel)
                        _panelStack.Push(panel);
                }
                else
                {
                    panel.Deactivate();  
                }
            }
        }

        private void ShowHideScreen(EventsProvider.ShowHideScreenEvent showHideScreenEvent)
        {
        }

        protected virtual void LateUpdate() 
        {
            if (!IsNeedFollowCamera || _camera == null)
                return;

            Vector3 forward = _camera.transform.forward;
            Vector3 position = _camera.transform.position + forward * 2f;

            transform.position = position;
            transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
        }

        public override void Deinitialize()
        {
            foreach (var panel in _panels) 
                panel.Deinitialize();
            
            _eventAggregator.Unsubscribe<EventsProvider.ShowHideScreenEvent>(ShowHideScreen);
            _eventAggregator.Unsubscribe<EventsProvider.QuestPanelActiveEvent>(ActivePanel);
            _eventAggregator.Unsubscribe<EventsProvider.TrainingPanelHideEvent>(ShowHidePanel);
            
            _closeButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
        }

        private void OnDestroy() => 
            Deinitialize();
    }
}