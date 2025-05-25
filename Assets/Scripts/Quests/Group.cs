using Interfaces;
using UnityEngine;

namespace Quests
{
    public class Group : MonoBehaviour, IExecutableGroup
    {
        public Step[] Steps;
        
        public void Initialize(IServiceLocator serviceLocator)
        {
            foreach (Step step in Steps)
            {
                step.Initialize(serviceLocator);
            }
        }

        public void StartGroup()
        {
            Steps[0].StartStep();
        }

        public void EndGroup()
        {
            throw new System.NotImplementedException();
        }

        public void Deinitialize()
        {
            throw new System.NotImplementedException();
        }
    }
}