using UnityEngine;
using Animancer;
using Pathfinding;

namespace SOD
{
    public class EnemyMoveState : EnemyState
    {
        private Transform targetPosition;
        private Path path;
        private float nextWaypointDistance = 3;
        private int currentWaypoint = 0;
        public bool reachedEndOfPath;

        public EnemyMoveState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            targetPosition = GameObject.FindObjectOfType<Player>().transform;
            PlayMoveAnimation();
        }

        public override void Update()
        {
            base.Update();

            if (Vector3.Distance(enemy.transform.position, targetPosition.position) <= enemy.Data.AttackRange &&
                enemy.IsAttackable == true)
            {
                enemyStateMachine.ToAttackState();
            }
            else if (Vector3.Distance(enemy.transform.position, targetPosition.position) <= enemy.Data.AttackRange &&
                enemy.IsAttackable == false)
            {
                enemyStateMachine.ToIdleState();
            }

            enemy.StartPath(enemy.transform.position, targetPosition.position, OnPathComplete);

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
            enemy.RotateSmoothly(dir);
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
            enemy.PlayAnimation(enemy.Data.MoveAnimationClip, enemy.Data.MoveSpeed);
        }

        private void OnPathComplete(Path p)
        {
            Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

            if (!p.error)
            {
                path = p;
                currentWaypoint = 0;
            }
        }
    }
}
