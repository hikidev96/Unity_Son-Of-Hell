using UnityEngine;

namespace SOD
{
    public class Player : GameActor
    {
        [SerializeField] private Animancer.AnimancerComponent animancer;
        [SerializeField] private PlayerData data;

        private Rotator rotator;
        private AnimationPlayer animationPlayer;

        public PlayerData Data => data;

        protected override void Awake()
        {
            base.Awake();

            rotator = new Rotator(this.transform);
            animationPlayer = new AnimationPlayer(animancer);
        }

        public void RotateSmoothly(Vector3 dir, bool considerCamera = false)
        {
            rotator.RotateSmoothly(dir, considerCamera);    
        }

        public void RotateDirectly(Vector3 dir, bool considerCamera = false)
        {
            rotator.RotateDirectly(dir, considerCamera);    
        }

        public void PlayAnimation(AnimationClip clip, float speed = 1.0f)
        {
            animationPlayer.Play(clip, speed);
        }
    }
}