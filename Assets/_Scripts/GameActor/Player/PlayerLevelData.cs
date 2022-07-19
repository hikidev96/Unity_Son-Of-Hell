using UnityEngine;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/PlayerData/LevelData")]
    public class PlayerLevelData : ScriptableObject
    {
        [HideInInspector] public int Level;

        private void OnEnable()
        {
            Level = 1;
        }
    }
}
