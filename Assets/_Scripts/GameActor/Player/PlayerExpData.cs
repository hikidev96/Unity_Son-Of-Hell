using UnityEngine;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/PlayerData/ExpData")]
    public class PlayerExpData : ScriptableObject
    {
        [HideInInspector] public float CurrentExp = 0.0f;
        [HideInInspector] public float MaxExp = 100.0f;

        private void OnEnable()
        {
            MaxExp = 100.0f;
            CurrentExp = 0.0f;
        }
    }
}
