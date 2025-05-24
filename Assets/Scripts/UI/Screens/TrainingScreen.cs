using Interfaces;
using Static;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class TrainingScreen : ScreenView
    {
        [Header("\nUI Elements")]
        [SerializeField] private Button _trainingScene;
        [SerializeField] private Button _exitButton;

        public override void Initialize(IEventAggregator eventAggregator, IServiceLocator serviceLocator, Camera camera)
        {
            base.Initialize(eventAggregator, serviceLocator, camera);
            
            _eventAggregator.Subscribe<EventsProvider.ShowHideScreenEvent>(ShowHideScreen);
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
        }
    }
}