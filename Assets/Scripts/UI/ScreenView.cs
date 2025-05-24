using Interfaces;
using Static;
using UnityEngine;

namespace UI
{
    public abstract class ScreenView : MonoBehaviour, IScreenView
    {
        [Header("\nScreen type")]
        public Enums.ScreenType ScreenType;
        
        [Header("\nCanvas type")]
        public Enums.CanvasType CanvasType;

        [Header("\nCanvas type")] 
        public bool IsNeedFollowCamera;
        
        [SerializeField] protected CanvasGroup _canvasGroup;
        
        protected IEventAggregator _eventAggregator;
        protected IServiceLocator _serviceLocator;
        protected Camera _camera;

        public virtual void Initialize(IEventAggregator eventAggregator, IServiceLocator serviceLocator, Camera camera)
        {
            _eventAggregator = eventAggregator;
            _serviceLocator = serviceLocator; 
            _camera = camera;
        }
        public abstract void Deinitialize();
        
        public void Show()
        {
            if (_canvasGroup !=null) 
                _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            if (_canvasGroup !=null)
                _canvasGroup.alpha = 0;
        }
    }
}