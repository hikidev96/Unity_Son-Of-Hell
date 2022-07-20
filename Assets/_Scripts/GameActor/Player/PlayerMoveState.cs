using UnityEngine;

namespace SOD
{
    public class PlayerMoveState : PlayerState
    {
        public PlayerMoveState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
        {
            
        }

        public override void Enter()
        {
            base.Enter();

            PlayMoveAnimation();

            ServiceProvider.InputService.OnDashKeyPress.AddListener(() => player.TryDash());
            player.HealthPoint.OnDie.AddListener(() => playerStateMachine.ToDeadState(this));
        }

        public override void Update()
        {
            base.Update();

            player.RotateTowardMouse();
            player.ApplyMovementValue();

            if (ServiceProvider.InputService.IsHandFireKeyPress == true)
            {
                player.TryNormalAttack();
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void PlayMoveAnimation()
        {
            player.PlayAnimation(player.Data.MoveAnimationClip, player.Data.MoveSpeed);
        }
    }
}