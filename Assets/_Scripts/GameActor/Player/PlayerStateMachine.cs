using UnityEngine;

namespace SOD
{   
    public class PlayerStateMachine : StateMachine
    {
        [SerializeField] private Player player;

        private PlayerMoveState moveState;

        protected override void Awake()
        {
            base.Awake();

            moveState = new PlayerMoveState(player, this);

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
    }
}
