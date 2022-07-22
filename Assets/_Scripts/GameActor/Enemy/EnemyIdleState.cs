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

            if (enemy.HealthPoint.IsDead == true)
            {
                enemyStateMachine.ToDeadState();
                return;
            }

            if (enemy.AI.PlayerIsInRange(enemy.AttackData.AttackRange) == false)
            {
                enemyStateMachine.ToMoveState();
            }
            else if (enemy.AI.PlayerIsInRange(enemy.AttackData.AttackRange) == true && enemy.IsAttackable == true)
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
            enemy.Animator.Play(enemy.AnimationData.IdleAnimationClip);
        }
    }
}