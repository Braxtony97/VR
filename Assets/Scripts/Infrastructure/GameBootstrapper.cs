using Infrastructure.GameStates;
using Interfaces;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private UIManager _uiManager;
        
        private Game _game;
        private IServiceLocator _serviceLocator;

        private void Awake()
        {
            _serviceLocator = new ServiceLocator();
            _serviceLocator.Register<IEventAggregator>(new EventAggregator());
            _serviceLocator.Register<ICoroutineRunner>(this);
            
            UIManager uiManager = Instantiate(_uiManager);
            uiManager.Init(_serviceLocator.Resolve<IEventAggregator>(), _serviceLocator);
            DontDestroyOnLoad(uiManager.gameObject);
            
            _serviceLocator.Register(uiManager);
                
            _game = new Game(_serviceLocator);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(gameObject);
        }
    }
}
