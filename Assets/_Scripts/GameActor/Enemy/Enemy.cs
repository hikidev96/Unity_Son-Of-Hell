using System.Collections;    
using UnityEngine;
using Animancer;
using Pathfinding;

namespace SOD
{
    [System.Serializable]
    public class EnemyData
    {
        [SerializeField] private float moveSpeed = 1.0f;
        [SerializeField] private float attackRange = 1.0f;
        [SerializeField] private float attackSpeed = 1.0f;
        [SerializeField] private float attackCoolTime = 3.0f;
        [SerializeReference] private AnimationClip idleAnimationClip;
        [SerializeReference] private AnimationClip moveAnimationClip;
        [SerializeReference] private AnimationClip attackAnimationClip;

        public AnimationClip IdleAnimationClip => idleAnimationClip;
        public AnimationClip MoveAnimationClip => moveAnimationClip;
        public AnimationClip AttackAnimationClip => attackAnimationClip;
        public float MoveSpeed => moveSpeed;
        public float AttackSpeed => attackSpeed;
        public float AttackRange => attackRange;
        public float AttackCoolTime => attackCoolTime;
    }

    public class Enemy : GameActor, IDamageable
    {
        [SerializeField] private EnemyData data;
        [SerializeField] private AnimancerComponent animancer;
        [SerializeField] private EnemyHealthPoint healthPoint;
        [SerializeField] private HitBox hitBox;
        [SerializeField] private Seeker seeker;
        [SerializeField] private CharacterControllerForcer forcer;

        private Rotator rotator;
        private AnimationPlayer animationPlayer;

        public EnemyData Data => data;
        public bool IsAttackable { get; private set; } = true;

        protected override void Awake()
        {
            base.Awake();

            rotator = new Rotator(this.transform);
            animationPlayer = new AnimationPlayer(animancer);
            hitBox.OnHit.AddListener((hitData) => Damage(hitData.DamageData));
        }

        public virtual void Damage(DamageData damageData)
        {
            healthPoint.Damage(damageData);
        }

        public void RotateSmoothly(Vector3 dir, bool considerCamera = false)
        {
            rotator.RotateSmoothly(dir, considerCamera);
        }

        public void RotateDirectly(Vector3 dir, bool considerCamera = false)
        {
            rotator.RotateDirectly(dir, considerCamera);
        }

        public void RotateTowardMouse(bool considerCamera = true)
        {
            rotator.RotateTowardMouse(considerCamera);
        }

        public void AddForce(Vector3 dir, float power)
        {
            forcer.AddForce(dir, power);
        }

        public AnimancerState PlayAnimation(AnimationClip clip, float speed = 1.0f)
        {
            return animationPlayer.Play(clip, speed);
        }

        public Path StartPath(Vector3 start, Vector3 end, OnPathDelegate callback)
        {
            return seeker.StartPath(start, end, callback);
        }

        public void StartCountAttackCoolTime()
        {
            StartCoroutine(CountAttackCoolTime());
        }

        private IEnumerator CountAttackCoolTime()
        {
            IsAttackable = false;

            yield return new WaitForSeconds(data.AttackCoolTime);

            IsAttackable = true;
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, data.AttackRange);
        }
    }
}