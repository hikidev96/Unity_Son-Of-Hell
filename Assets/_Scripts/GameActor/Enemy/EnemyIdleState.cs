using UnityEngine;

namespace SOD
{
    public class EnemyIdleState : EnemyState
    {
        private Transform targetPosition;

        public EnemyIdleState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            targetPosition = GameObject.FindObjectOfType<Player>().transform;
            PlayIdleAnimation();
        }

        public override void Update()
        {
            base.Update();

            if (Vector3.Distance(enemy.transform.position, targetPosition.position) > enemy.Data.AttackRange)
            {
                enemyStateMachine.ToMoveState();
            }
            else if (Vector3.Distance(enemy.transform.position, targetPosition.position) <= enemy.Data.AttackRange &&
                    enemy.IsAttackable == true)
            {
                enemyStateMachine.ToAttackState();
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void PlayIdleAnimation()
        {
            var animationState = enemy.PlayAnimation(enemy.Data.IdleAnimationClip);
        }
    }
}
