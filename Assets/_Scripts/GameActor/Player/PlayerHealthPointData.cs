using UnityEngine;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/PlayerData/HealthPointData")]
    public class PlayerHealthPointData : ScriptableObject
    {
        [HideInInspector] public float MaxHp = 100.0f;
        [HideInInspector] public float CurrentHp = 0.0f;
        [HideInInspector] public bool IsDead = false;

        private void OnEnable()
        {
            MaxHp = 100.0f;
            CurrentHp = MaxHp;
            IsDead = false;
        }
    }
}
