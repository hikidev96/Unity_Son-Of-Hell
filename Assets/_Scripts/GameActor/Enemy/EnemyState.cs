using UnityEngine;

namespace SOD
{
    public class EnemyState : State
    {
        protected EnemyStateMachine enemyStateMachine;
        protected Enemy enemy;

        public EnemyState(Enemy enemy, StateMachine stateMachine) : base(stateMachine)
        {
            this.enemyStateMachine = stateMachine as EnemyStateMachine;
            this.enemy = enemy;
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