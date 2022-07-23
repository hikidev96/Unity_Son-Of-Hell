using UnityEngine;
using Sirenix.OdinInspector;

namespace SOD
{
    public class Player : GameActor
    {
        [SerializeField, BoxGroup("Base")] private Animancer.AnimancerComponent animancer;
        [SerializeField, BoxGroup("Data")] private PlayerAnimationData animationData;
        [SerializeField, BoxGroup("Data")] private PlayerMovementData movementData;
        [SerializeField, BoxGroup("Data")] private PlayerTransformData transformData;
        [SerializeField] private HandController handController;
        [SerializeField] private DashController dashController;
        [SerializeField] private ExpBehaviour expBehaviour;
        [SerializeField] private PlayerHealthPoint healthPoint;
        
        private PlayerMovementValueController movementValueController;
        private Animator animationPlayer;

        public PlayerAnimationData AnimationData => animationData;        
        public PlayerMovementData MovementData => movementData;
        public HandController HandController => handController;
        public ExpBehaviour ExpBehaviour => expBehaviour;   
        public HealthPoint HealthPoint => healthPoint;  

        protected override void Awake()
        {
            base.Awake();
            transformData.Set(this.transform);
            healthPoint.Init();            
            movementValueController = new PlayerMovementValueController(this, animancer);
            animationPlayer = new Animator(animancer);
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