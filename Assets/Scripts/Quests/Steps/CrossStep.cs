using Interfaces;
using UnityEngine;

namespace Quests.Steps
{
    public class CrossStep : Step
    {
        public override string Description { get; set; } = "Пересечь серую зону";
        
        [Header("Stage Parameters\n")]
        [SerializeField] private Collider _collider;

        public override void Initialize(IServiceLocator serviceLocator, Group group)
        {
            base.Initialize(serviceLocator, group);
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
            _collider.enabled = false;
            base.EndStep();
        }

        public override void Deinitialize()
        {
            base.Deinitialize();
        }
    }
}