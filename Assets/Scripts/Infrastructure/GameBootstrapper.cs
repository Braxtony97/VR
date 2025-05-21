using Infrastructure.GameStates;
using Interfaces;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private UIRoot _uiRoot;
        
        private Game _game;

        private void Awake()
        {
            var uiRoot = Instantiate(_uiRoot);
            _game = new Game(this, uiRoot);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(gameObject);
        }
    }
}
