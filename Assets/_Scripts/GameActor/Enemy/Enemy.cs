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
        [SerializeReference] private AnimationClip deadAnimationClip;

        public AnimationClip IdleAnimationClip => idleAnimationClip;
        public AnimationClip MoveAnimationClip => moveAnimationClip;
        public AnimationClip AttackAnimationClip => attackAnimationClip;
        public AnimationClip DeadAnimationClip => deadAnimationClip;
        public float MoveSpeed => moveSpeed;
        public float AttackSpeed => attackSpeed;
        public float AttackRange => attackRange;
        public float AttackCoolTime => attackCoolTime;
    }

    [RequireComponent(typeof(AnimancerComponent))]    
    public class Enemy : GameActor
    {
        [SerializeField] private EnemyData data;
        [SerializeField] private EnemyHealthPoint healthPoint;
        [SerializeField] private GameObject destroyFXPrefab;
        [SerializeField] private EnemyAI ai;

        private AnimancerComponent animancer;
        private CharacterControllerForcer forcer;

        public EnemyHealthPoint HealthPoint => healthPoint;
        public EnemyData Data => data;
        public CharacterControllerForcer Forcer => forcer;
        public EnemyAI AI => ai;
        public Animator Animator { get; private set; }
        public Rotator Rotator { get; private set; }
        public bool IsAttackable { get; private set; } = true;

        protected override void Awake()
        {
            base.Awake();

            animancer = GetComponent<AnimancerComponent>();
            forcer = GetComponent<CharacterControllerForcer>();

            healthPoint.Init();
            Rotator = new Rotator(this.transform);
            Animator = new Animator(animancer);            
        }

        public void GivePlayerEXP()
        {
            ai.Player.HandController.Hand.AddEXP(5.0f);
        }

        public void StartCountAttackCoolTime()
        {
            StartCoroutine(CountAttackCoolTime());
        }        

        public void InvokeDestroySelfAfter(float time)
        {
            Invoke("DestroySelf", time);
        }

        public void DestroySelf()
        {            
            Instantiate(destroyFXPrefab, GetActorPart(EActorPart.Middle), Quaternion.identity);
            Destroy(this.gameObject);
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