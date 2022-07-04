using UnityEngine;

namespace SOD
{
    public class PlayerState : State
    {
        protected PlayerStateMachine playerStateMachine;
        protected Player player;

        public PlayerState(Player player, PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
            this.player = player;
            this.playerStateMachine = playerStateMachine;
        }

        public override void Enter()
        {
            base.Enter();
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
    }
}
