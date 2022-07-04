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
        }

        public override void Update()
        {
            base.Update();            

            if (ServiceProvider.InputService.MovementValue == Vector3.zero)
            {
                playerStateMachine.ToIdleState();
                return;
            }

            player.RotateSmoothly(ServiceProvider.InputService.MovementValue, true);
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
            player.PlayAnimation(player.Data.RunAnimationClip);
        }
    }
}
