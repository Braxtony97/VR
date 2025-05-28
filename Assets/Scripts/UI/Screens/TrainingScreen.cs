using Interfaces;
using Quests;
using Static;
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
        

        public override void Initialize(IEventAggregator eventAggregator, IServiceLocator serviceLocator, Camera camera)
        {
            base.Initialize(eventAggregator, serviceLocator, camera);
            
            _eventAggregator.Subscribe<EventsProvider.ShowHideScreenEvent>(ShowHideScreen);
            _eventAggregator.Subscribe<EventsProvider.QuestPanelActiveEvent>(ActivePanel);
            
            _closeButton.onClick.AddListener(() => Hide());

            foreach (var panel in _panels) 
                panel.Initialize(_serviceLocator);
        }

        private void ActivePanel(EventsProvider.QuestPanelActiveEvent questPanelActiveEvent)
        {
            if (questPanelActiveEvent == null || _panels == null) return;
            
            foreach (var panel in _panels)
            {
                if (panel.TrainingPanelUI == questPanelActiveEvent.Panel)
                {
                    panel.Activate();
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
            _eventAggregator.Unsubscribe<EventsProvider.ShowHideScreenEvent>(ShowHideScreen);
        }
    }
}