using UnityEngine;
using Animancer;

namespace SOD
{
    public class PlayerDeadState : PlayerState
    {
        public PlayerDeadState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();

            PlayDeadAnimation().Events.OnEnd = () =>
            {
                ServiceProvider.UIService.ShowGameOverUI();
                ServiceProvider.CameraService.SetDepthOfField(300.0f);
            };

            ServiceProvider.InputService.DisableAttackInput();
            ServiceProvider.InputService.DisableInteractionInput();
            ServiceProvider.InputService.DisableMovementInput();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private AnimancerState PlayDeadAnimation()
        {
            return player.PlayAnimation(player.Data.DeadAnimationClip, player.Data.MoveSpeed);
        }
    }
}
