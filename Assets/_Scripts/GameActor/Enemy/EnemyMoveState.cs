using UnityEngine;
using Animancer;
using Pathfinding;

namespace SOD
{
    public class EnemyMoveState : EnemyState
    {
        private Path path;
        private float nextWaypointDistance = 3;
        private int currentWaypoint = 0;
        private AnimancerState moveAnimationState;

        public bool reachedEndOfPath;

        public EnemyMoveState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();

            PlayMoveAnimation();
        }

        public override void Update()
        {
            base.Update();

            moveAnimationState.Speed = enemy.MovementData.MoveSpeed;

            if (enemy.HealthPoint.IsDead == true)
            {
                enemyStateMachine.ToDeadState();
                return;
            }

            if (enemy.AI.PlayerIsInRange(enemy.AttackData.AttackRange) == true)
            {
                if (enemy.IsAttackable == true)
                {
                    enemyStateMachine.ToAttackState();
                }
                else
                {
                    enemyStateMachine.ToIdleState();
                }
            }

            MoveToPlayer();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void PlayMoveAnimation()
        {
            moveAnimationState = enemy.Animator.Play(enemy.AnimationData.MoveAnimationClip, enemy.MovementData.MoveSpeed);
        }

        private void MoveToPlayer()
        {
            enemy.AI.CalculatePath(OnPathComplete);

            if (path == null)
            {
                return;
            }

            reachedEndOfPath = false;
            float distanceToWaypoint;

            while (true)
            {
                distanceToWaypoint = Vector3.Distance(enemy.transform.position, path.vectorPath[currentWaypoint]);
                if (distanceToWaypoint < nextWaypointDistance)
                {
                    if (currentWaypoint + 1 < path.vectorPath.Count)
                    {
                        currentWaypoint++;
                    }
                    else
                    {
                        reachedEndOfPath = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            Vector3 dir = (path.vectorPath[currentWaypoint] - enemy.transform.position).normalized;
            enemy.Rotator.RotateSmoothly(dir);
        }

        private void OnPathComplete(Path p)
        {
            //Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

            if (!p.error)
            {
                path = p;
                currentWaypoint = 0;
            }
        }
    }
}
