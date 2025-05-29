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
            
            _serviceLocator.Resolve<IEventAggregator>().Subscribe<EventsProvider.QuestEndedEvent>(QuestEnded);
        }
        
        private void TrainingSceneLoaded()
        {
            _serviceLocator.Resolve<UIManager>().CreateScreen(Enums.ScreenType.TrainingScreen);

            PlayModeSceneManager playeModeSceneManager = PlayModeSceneManager.Instance;
            playeModeSceneManager.QuestManager.Initialize(_serviceLocator);
            playeModeSceneManager.QuestManager.StartQuest();
        }

        private void QuestEnded(EventsProvider.QuestEndedEvent questEndedEvent)
        {
            _serviceLocator.Resolve<IEventAggregator>().Unsubscribe<EventsProvider.QuestEndedEvent>(QuestEnded);
        }

        public void Exit()
        {
        }
    }
}