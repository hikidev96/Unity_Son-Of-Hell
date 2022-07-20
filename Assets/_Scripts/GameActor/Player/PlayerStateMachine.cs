using UnityEngine;

namespace SOD
{   
    public class PlayerStateMachine : StateMachine
    {
        [SerializeField] private Player player;

        private PlayerMoveState moveState;
        private PlayerDeadState deadState;

        protected override void Awake()
        {
            base.Awake();

            moveState = new PlayerMoveState(player, this);
            deadState = new PlayerDeadState(player, this);

            SetStartState(moveState);
        }
        
        public void ToMoveState(State currentState)
        {
            if (currentState != this.currentState)
            {
                return;
            }

            ChangeState(moveState);
        }

        public void ToDeadState(State currentState)
        {
            if (currentState != this.currentState)
            {
                return;
            }

            ChangeState(deadState);
        }
    }
}
