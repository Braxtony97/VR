using Interfaces;
using UnityEngine;

namespace Quests
{
    public class QuestsManager : MonoBehaviour  
    {
        public Group[] Groups;

        public void Initialize(IServiceLocator serviceLocator)
        {
            foreach (Group group in Groups)
            {
                group.Initialize(serviceLocator);
            }
        }

        public void StartGroups()
        {
            Groups[0].StartGroup();
        }
    }
}