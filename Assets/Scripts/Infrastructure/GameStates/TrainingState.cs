using System;
using Interfaces;
using Static;
using UI;

namespace Infrastructure.GameStates
{
    public class TrainingState : IPayloadState<string>
    {
        private readonly IServiceLocator _serviceLocator;

        public TrainingState(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Enter(string payload)
        {
            _serviceLocator.Resolve<UIManager>().CreateScreen(Enums.ScreenType.LoadingScreen);
            _serviceLocator.Resolve<SceneLoader>().Load(payload, TrainingSceneLoaded);
        }

        private void TrainingSceneLoaded()
        {
            _serviceLocator.Resolve<UIManager>().CreateScreen(Enums.ScreenType.TrainingScreen);
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}