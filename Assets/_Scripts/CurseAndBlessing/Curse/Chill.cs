using UnityEngine;

namespace SOD
{
    public class Chill : Curse
    {
        private void OnEnable()
        {
            this.GetComponent<Enemy>().MovementData.AddMoveSpeedVariance(-0.5f);
        }

        private void OnDisable()
        {
            this.GetComponent<Enemy>().MovementData.AddMoveSpeedVariance(0.5f);
        }
    }
}
