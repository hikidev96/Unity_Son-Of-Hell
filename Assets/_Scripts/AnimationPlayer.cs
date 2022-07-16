using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOD
{
    public class AnimationPlayer : MonoBehaviour
    {        
        [SerializeField] private AnimationClip clip;
        [SerializeField] private bool onStart;

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
                animator.Play(clip);
            }
        }
    }
}
