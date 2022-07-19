using UnityEngine;

namespace SOD
{
    public class HandOrb : Orb
    {
        [SerializeField] private Interaction interaction;

        private void Awake()
        {
            interaction.OnInteract.AddListener(Activate);
        }

        public override void Activate()
        {
            base.Activate();

            ServiceProvider.UIService.OpenCardSelector();
            ServiceProvider.UnitService.SpawnEnemySpawner();
        }
    }
}
