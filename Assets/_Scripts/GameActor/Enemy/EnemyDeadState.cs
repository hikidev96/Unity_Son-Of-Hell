using UnityEngine;

namespace SOD
{
    public class EnemyDeadState : EnemyState
    {
        public EnemyDeadState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
        {
       
        }

        public override void Enter()
        {
            base.Enter();

            PlayDeadAnimation();
            enemy.InvokeDestroySelfAfter(3.0f);
            enemy.HealthPoint.DisableHitBox();
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

        private void PlayDeadAnimation()
        {
            enemy.Animator.Play(enemy.AnimationData.DeadAnimationClip);
        }
    }
}