using UnityEngine;
using Animancer;

namespace SOD
{
    public class AnimationPlayer
    {
        private AnimancerComponent animancer;

        public AnimationPlayer(AnimancerComponent animancer)
        {
            this.animancer = animancer;
        }

        public AnimancerState Play(AnimationClip clip, float speed = 1.0f)
        {
            var result = animancer.Play(clip: clip, fadeDuration: 0.1f);
            result.Speed = speed;

            return result;
        }
    }
}