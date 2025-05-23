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
            UIManager uiManager = Instantiate(_uiManager);
            DontDestroyOnLoad(uiManager.gameObject);
            
            _serviceLocator = new ServiceLocator();
            _serviceLocator.Register<ICoroutineRunner>(this);
            _serviceLocator.Register(uiManager);
                
            _game = new Game(_serviceLocator);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(gameObject);
        }
    }
}
