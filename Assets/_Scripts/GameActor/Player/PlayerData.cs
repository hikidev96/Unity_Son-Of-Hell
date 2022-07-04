using UnityEngine;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private AnimationClip idleAnimationClip;
        [SerializeField] private AnimationClip runAnimationClip;        

        public AnimationClip IdleAnimationClip => idleAnimationClip;
        public AnimationClip RunAnimationClip => runAnimationClip;
    }
}
