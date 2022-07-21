using UnityEngine;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/PlayerData/HandData")]
    public class PlayerHandData : ScriptableObject
    {
        public Hand Hand;

        private void OnEnable()
        {
            Hand = null;
        }
    }
}
