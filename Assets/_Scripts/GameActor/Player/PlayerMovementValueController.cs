using UnityEngine;
using Animancer;

namespace SOD
{
    public class PlayerMovementValueController 
    {
        private MixerState<Vector2> moveState;
        private Player player;

        public PlayerMovementValueController(Player player, AnimancerComponent animancer)
        {
            this.player = player;

            var state = animancer.States.GetOrCreate(player.AnimationData.MoveAnimationClip);
            moveState = (MixerState<Vector2>)state;
        }

        public void ApplyMovementValue()
        {
            var movementValueConsideringPlayerRot = Quaternion.Euler(0.0f, player.transform.rotation.eulerAngles.y * -1, 0.0f) * ServiceProvider.InputService.MovementValue;
            var movementValueConsideringCameraRot = Quaternion.Euler(0.0f, Camera.main.transform.rotation.eulerAngles.y, 0.0f) * movementValueConsideringPlayerRot;
            moveState.Parameter = new Vector2(movementValueConsideringCameraRot.x, movementValueConsideringCameraRot.z);
        }
    }
}
