namespace Static
{
    public static class Enums
    {
        public enum ScreenType
        {
            LoadingScreen,
            MainMenu,
            TrainingScreen
        }

        public enum CanvasType
        {
            Overlay,
            WorldSpace
        }

        public enum SceneType
        {
            MainMenu,
            Training
        }

        public enum StepStage
        {
            Cross,
            EyeContact,
            Grab,
            Push
        }
        
        public enum GroupStage
        {
            CrossGrabPush,
            PushGrab,
        }
        
        public enum TrainingPanelUI
        {
            MainMenu,
            Instruction,
            Group,
            Step,
            Result
        }
    }
}