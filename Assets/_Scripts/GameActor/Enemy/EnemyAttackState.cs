using UnityEngine;

namespace SOD
{
    public class EnemyAttackState : EnemyState
    {
        public EnemyAttackState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();

            PlayAttackAnimation();
            enemy.StartCountAttackCoolTime();
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

        private void PlayAttackAnimation()
        {
            var animationState = enemy.PlayAnimation(enemy.Data.AttackAnimationClip, enemy.Data.AttackSpeed);
            animationState.Events.OnEnd = () => enemyStateMachine.ToIdleState();
        }
    }
}