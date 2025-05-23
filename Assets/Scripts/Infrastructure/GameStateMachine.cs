using System;
using System.Collections.Generic;
using Infrastructure.GameStates;
using Interfaces;
using UI;
using Unity.VisualScripting;
using IState = Interfaces.IState;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private readonly IServiceLocator _serviceLocator;
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;
        public GameStateMachine(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
        
        public void Init()
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(_serviceLocator),
                [typeof(MainMenuState)] = new MainMenuState(_serviceLocator),
            };
        }
        
        public void Enter<TState>() where TState : IState
        {
            var state = GetState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : IPayloadState<TPayload>
        {
            var state = GetState<TState>();
            state.Enter(payload);
        }

        private TState GetState<TState>() where TState : IExitableState
        {
            _currentState?.Exit();
            var state = (TState) _states[typeof(TState)];
            _currentState = state;
            return state;
        }
    }
}