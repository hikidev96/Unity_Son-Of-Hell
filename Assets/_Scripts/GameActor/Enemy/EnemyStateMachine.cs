using UnityEngine;

namespace SOD
{
    public class EnemyStateMachine : StateMachine
    {
        [SerializeField] private Enemy enemy;

        private EnemyIdleState idleState;
        private EnemyMoveState moveState;
        private EnemyAttackState attackState;
        private EnemyDeadState deadState;

        protected override void Awake()
        {
            base.Awake();

            idleState = new EnemyIdleState(enemy, this);
            moveState = new EnemyMoveState(enemy, this);
            attackState = new EnemyAttackState(enemy, this);
            deadState = new EnemyDeadState(enemy, this);

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

        public void ToAttackState()
        {
            ChangeState(attackState);
        }

        public void ToDeadState()
        {
            ChangeState(deadState);
        }
    }
}