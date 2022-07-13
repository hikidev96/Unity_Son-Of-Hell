using UnityEngine;
using Animancer;

namespace SOD
{
    public class Animator
    {
        private AnimancerComponent animancer;

        public Animator(AnimancerComponent animancer)
        {
            this.animancer = animancer;
        }

        public AnimancerState Play(AnimationClip clip, float speed = 1.0f)
        {
            var result = animancer.Play(clip: clip, fadeDuration: 0.1f);
            result.NormalizedTime = 0.0f;
            result.Speed = speed;

            return result;
        }

        public AnimancerState Play(Animancer.ITransition transition, float speed = 1.0f)
        {
            var result = animancer.Play(transition, fadeDuration: 0.1f);
            result.NormalizedTime = 0.0f;
            result.Speed = speed;

            return result;
        }
    }
}