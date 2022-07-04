using UnityEngine;

namespace SOD
{   
    public class PlayerStateMachine : StateMachine
    {
        [SerializeField] private Player player;

        private PlayerIdleState idleState;
        private PlayerMoveState moveState;

        protected override void Awake()
        {
            base.Awake();

            idleState = new PlayerIdleState(player, this);
            moveState = new PlayerMoveState(player, this);

            SetStartState(idleState);
        }

        public void ToIdleState()
        {
            ChangeState(idleState);
        }
        
        public void ToMoveState()
        {
            ChangeState(moveState);
        }
    }
}
