using Quests;

namespace Static
{
    public static class EventsProvider
    {
        public class LoadSceneEvent
        {
            public Enums.SceneType Scene;

            public LoadSceneEvent(Enums.SceneType scene) => 
                Scene = scene;
        }
        
        public class ShowHideScreenEvent
        {
            public Enums.ScreenType Screen;
            public bool IsShowing;

            public ShowHideScreenEvent(Enums.ScreenType screen, bool isShowing)
            {
                Screen = screen;
                IsShowing = isShowing;
            } 
        }
        
        public class StepStartedEvent
        {
            public Enums.StepStage Stage;

            public StepStartedEvent(Step step) => 
                Stage = step.StepStage;
        }

        public class StepEndedEvent
        {
            public Enums.StepStage StepStage;

            public StepEndedEvent(Step step) => 
                StepStage = step.StepStage;
        }

        public class ObjectDropZoneEvent
        {
            public readonly bool IsObjectDropZone;

            public ObjectDropZoneEvent(bool isObjectDropZone)
            {
                IsObjectDropZone = isObjectDropZone;
            }
        }
    }
}