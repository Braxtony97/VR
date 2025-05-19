using System;
using System.Collections.Generic;
using Infrastructure.GameStates;
using Interfaces;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;
        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(MainMenuState)] = new MainMenuState(this, sceneLoader),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            var state = GetState<TState>();
            state.Enter();
        }
        
        public void Enter<T

        private TState GetState<TState>() where TState : IExitableState
        {
            _currentState?.Exit();
            var state = (TState) _states[typeof(TState)];
            _currentState = state;
            return state;
        }
    }
}