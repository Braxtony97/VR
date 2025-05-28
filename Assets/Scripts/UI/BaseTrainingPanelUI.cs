using Interfaces;
using Static;
using UnityEngine;

namespace UI
{
    public abstract class BaseTrainingPanelUI : MonoBehaviour
    {
        public Enums.TrainingPanelUI TrainingPanelUI;
        
        [SerializeField] protected GameObject _mainPanel;
        [SerializeField] protected Transform _container;
        protected IServiceLocator _serviceLocator;
        protected IEventAggregator _eventAggregator;
        
        public bool IsActive => _mainPanel.activeSelf;

        public virtual void Initialize(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _eventAggregator = _serviceLocator.Resolve<IEventAggregator>();
        }

        public virtual void Activate()
        {
            if (_mainPanel == null)
                return;
            
            if (!IsActive)
            {
                _mainPanel.SetActive(true);
            }
            
            Debug.Log("Active Panel Activated");
                
        }

        public virtual void Deactivate()
        {
            if (_mainPanel == null)
                return;

            if (IsActive)
                _mainPanel.SetActive(false);
        }
    }
}