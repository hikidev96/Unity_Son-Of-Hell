using UnityEngine;

namespace SOD
{
    public class HandOrb : Orb
    {
        public override void Activate()
        {
            base.Activate();

            ServiceProvider.UIService.OpenCardSelector();
        }
    }
}
