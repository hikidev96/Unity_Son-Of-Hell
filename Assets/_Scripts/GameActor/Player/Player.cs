using UnityEngine;

namespace SOD
{
    public class Player : GameActor
    {        
        [SerializeField] private Animancer.AnimancerComponent animancer;
        [SerializeField] private PlayerData data;

        private Rotator rotator;
        private PlayerMovementValueController movementValueController;
        private AnimationPlayer animationPlayer;

        public PlayerData Data => data;

        protected override void Awake()
        {
            base.Awake();

            rotator = new Rotator(this.transform);
            movementValueController = new PlayerMovementValueController(this, animancer);
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

        public void RotateTowardMouse(bool considerCamera = true)
        {
            rotator.RotateTowardMouse(considerCamera);
        }

        public Animancer.AnimancerState PlayAnimation(AnimationClip clip, float speed = 1.0f)
        {
            return animationPlayer.Play(clip, speed);
        }

        public Animancer.AnimancerState PlayAnimation(Animancer.ITransition clip, float speed = 1.0f)
        {
            return animationPlayer.Play(clip, speed);
        }

        public void ApplyMovementValue()
        {
            movementValueController.ApplyMovementValue();
        }
    }
}