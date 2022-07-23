using UnityEngine;
using Animancer;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/PlayerData")]
    public class PlayerAnimationData : ScriptableObject
    {
        [SerializeField] private AnimationClip deadAnimationClip;
        [SerializeReference] private ITransition moveAnimationClip;

        public AnimationClip DeadAnimationClip => deadAnimationClip;
        public ITransition MoveAnimationClip => moveAnimationClip;              
    }
}