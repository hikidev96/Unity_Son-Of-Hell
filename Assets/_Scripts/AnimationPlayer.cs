using UnityEngine;

namespace SOD
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private AnimationClip clip;
        [SerializeField] private bool onStart;
        [SerializeField] private bool destroyWhenAnimationEnd;

        private Animator animator;
        private Animancer.AnimancerComponent animancer;

        private void Awake()
        {
            animancer = GetComponent<Animancer.AnimancerComponent>();
            animator = new Animator(animancer);
        }

        private void Start()
        {
            if (onStart == true)
            {
                Play();
            }
        }

        public void Play(float speed = 1.0f)
        {
            Animancer.AnimancerState animationState = null;

            animationState = animator.Play(clip, speed);

            if (destroyWhenAnimationEnd == true)
            {
                animationState.Events.OnEnd = () => Destroy(this.gameObject);
            }
        }
    }
}
