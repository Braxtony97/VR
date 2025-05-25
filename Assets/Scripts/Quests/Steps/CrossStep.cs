using Interfaces;
using UnityEngine;

namespace Quests.Steps
{
    public class CrossStep : Step
    {
        [Header("Stage Parameters\n")]
        [SerializeField] private Collider _collider;

        public override void Initialize(IServiceLocator serviceLocator)
        {
            base.Initialize(serviceLocator);
            _collider.enabled = false;
        }
        
        public override void StartStep()
        {
            base.StartStep();
            _collider.enabled = true;
        }
        
        private void OnTriggerEnter(Collider player)
        {
            if (player.tag == MainCamera)
            {
                EndStep();
            }
        }
        
        public override void EndStep()
        {
            base.EndStep();
            _collider.enabled = false;
        }
    }
}