using UnityEngine;

namespace SOD
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
        {
            
        }

        public override void Enter()
        {
            base.Enter();

            PlayIdleAnimation();
        }

        public override void Update()
        {
            base.Update();

            if (ServiceProvider.InputService.MovementValue != Vector3.zero)
            {
                playerStateMachine.ToMoveState();
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

        private void PlayIdleAnimation()
        {
            player.PlayAnimation(player.Data.IdleAnimationClip);
        }
    }
}