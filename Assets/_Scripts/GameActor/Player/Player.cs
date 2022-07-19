using UnityEngine;

namespace SOD
{
    public class Player : GameActor
    {
        [SerializeField] private Animancer.AnimancerComponent animancer;
        [SerializeField] private PlayerData data;
        [SerializeField] private HandController handController;
        [SerializeField] private DashController dashController;
        [SerializeField] private ExpBehaviour expBehaviour;

        private Rotator rotator;
        private PlayerMovementValueController movementValueController;
        private Animator animationPlayer;

        public PlayerData Data => data;        
        public HandController HandController => handController;
        public ExpBehaviour ExpBehaviour => expBehaviour;    

        protected override void Awake()
        {
            base.Awake();

            rotator = new Rotator(this.transform);
            movementValueController = new PlayerMovementValueController(this, animancer);
            animationPlayer = new Animator(animancer);
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

        public void TryNormalAttack()
        {
            handController.TryAttack();
        }

        public void TryDash()
        {
            dashController.TryDash();
        }
    }
}