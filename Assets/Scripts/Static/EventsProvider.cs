using Quests;
using UnityEngine;

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
            public Step Step;
            public Enums.StepStage Stage;

            public StepStartedEvent(Step step)
            {
                Step = step;
                Stage = step.StepStage;
            }
        }

        public class StepEndedEvent
        {
            public readonly Enums.StepStage StepStage;
            public readonly Group GroupOwner;

            public StepEndedEvent(Step step, Group groupOwner)
            { 
                StepStage = step.StepStage;
                GroupOwner = groupOwner;
            }
        }

        public class ObjectDropZoneEvent
        {
            public readonly bool IsObjectDropZone;

            public ObjectDropZoneEvent(bool isObjectDropZone)
            {
                IsObjectDropZone = isObjectDropZone;
            }
        }

        public class PushButtonEvent
        {
            public PushButtonEvent() { }
        }
        
        public class GroupStartEvent
        {
            public Enums.GroupStage GroupStage;
            public Group Group;

            public GroupStartEvent(Group group)
            {
                GroupStage = group.GroupStage;
                Group = group;
            } 
        }

        public class GroupEndedEvent
        {
            public Enums.GroupStage GroupStage;

            public GroupEndedEvent(Group group) => 
                GroupStage = group.GroupStage;
        }

        public class QuestEndedEvent
        {
            public QuestEndedEvent(QuestsManager questsManager) { }
        }

        public class QuestPanelActiveEvent
        {
            public Enums.TrainingPanelUI Panel; 
            public QuestPanelActiveEvent(Enums.TrainingPanelUI questPanelUI)
            {
                Panel = questPanelUI;
            }
        }

        public class TrainingPanelHideEvent
        {
            public bool IsShowing;
            public TrainingPanelHideEvent(bool isShow) => 
                IsShowing = isShow;
        }
    }
}