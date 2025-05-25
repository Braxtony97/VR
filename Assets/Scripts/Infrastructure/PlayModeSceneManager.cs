using Quests;
using UnityEngine;

namespace Infrastructure
{
    public class PlayModeSceneManager : MonoBehaviour
    {
        public static PlayModeSceneManager Instance;
        
        public QuestsManager QuestManager;

        void Awake()
        {
            Instance = this;
        }
    }
}