namespace Static
{
    public static class EventsProvider
    {
        public class LoadSceneEvent
        {
            public Enums.SceneType Scene;

            public LoadSceneEvent(Enums.SceneType scene)
            {
                Scene = scene;
            }
        }
    }
}