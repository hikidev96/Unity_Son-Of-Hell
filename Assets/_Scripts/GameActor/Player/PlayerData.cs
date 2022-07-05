using UnityEngine;
using Animancer;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float moveSpeed = 2.0f;
        [SerializeReference] private ITransition moveAnimationClip;

        public ITransition MoveAnimationClip => moveAnimationClip;
        public float MoveSpeed => moveSpeed;
    }
}