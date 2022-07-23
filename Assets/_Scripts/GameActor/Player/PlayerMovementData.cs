using UnityEngine;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/PlayerData/MovementData")]
    public class PlayerMovementData : ScriptableObject
    {
        [SerializeField] private float moveSpeed = 2.0f;

        public float MoveSpeed => moveSpeed;
    }
}
