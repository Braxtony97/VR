using Infrastructure.GameStates;
using Interfaces;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private UIManager _uiManager;
        
        private Game _game;

        private void Awake()
        {
            UIManager uiManager = Instantiate(_uiManager);
            DontDestroyOnLoad(uiManager.gameObject);
                
            _game = new Game(this, uiManager);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(gameObject);
        }
    }
}
