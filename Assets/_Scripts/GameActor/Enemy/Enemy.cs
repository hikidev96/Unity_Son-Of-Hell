using System.Collections;
using UnityEngine;
using Animancer;
using Sirenix.OdinInspector;

namespace SOD
{
    #region Data
    [System.Serializable]
    public class EnemyAnimationData
    {
        [SerializeReference] private AnimationClip idleAnimationClip;
        [SerializeReference] private AnimationClip moveAnimationClip;
        [SerializeReference] private AnimationClip attackAnimationClip;
        [SerializeReference] private AnimationClip deadAnimationClip;

        public AnimationClip IdleAnimationClip => idleAnimationClip;
        public AnimationClip MoveAnimationClip => moveAnimationClip;
        public AnimationClip AttackAnimationClip => attackAnimationClip;
        public AnimationClip DeadAnimationClip => deadAnimationClip;
    }

    [System.Serializable]
    public class EnemyMovementData
    {
        [SerializeField] private float moveSpeedBase = 1.0f;
        [SerializeField] private float moveSpeedVariance = 1.0f;

        public float MoveSpeed => moveSpeedBase * moveSpeedVariance;

        public void AddMoveSpeedVariance(float value)
        {
            moveSpeedVariance += value;

            if (moveSpeedVariance < 0.0f)
            {
                moveSpeedVariance = 0.0f;
            }
        }
    }

    [System.Serializable]
    public class EnemyAttackData
    {
        [SerializeField] private float attackRange = 1.0f;
        [SerializeField] private float attackSpeed = 1.0f;
        [SerializeField] private float attackCoolTime = 3.0f;
        [SerializeField] private float attackRadius = 1.0f;
        [SerializeField] private Transform attackTrans;

        public float AttackSpeed => attackSpeed;
        public float AttackRange => attackRange;
        public float AttackCoolTime => attackCoolTime;
        public float AttackRadius => attackRadius;
        public Transform AttackTrans => attackTrans;
    }
    #endregion    

    [RequireComponent(typeof(AnimancerComponent))]    
    public class Enemy : GameActor
    {        
        [SerializeField, BoxGroup("Data")] private EnemyAnimationData animationData;
        [SerializeField, BoxGroup("Data")] private EnemyMovementData movementData;
        [SerializeField, BoxGroup("Data")] private EnemyAttackData attackData;
        [SerializeField, BoxGroup("Base")] private EnemyHealthPoint healthPoint;
        [SerializeField, BoxGroup("Base")] private EnemyAI ai;
        [SerializeField, BoxGroup("Destruction")] private GameObject destructionFXPrefab;
        [SerializeField, BoxGroup("Destruction")] private GameObject expOrbPrefab;        

        private AnimancerComponent animancer;
        private CharacterControllerForcer forcer;

        public EnemyHealthPoint HealthPoint => healthPoint;
        public EnemyAnimationData AnimationData => animationData;
        public EnemyAttackData AttackData => attackData;
        public EnemyMovementData MovementData => movementData;
        public CharacterControllerForcer Forcer => forcer;
        public EnemyAI AI => ai;
        public Animator Animator { get; private set; }
        public bool IsAttackable { get; private set; } = true;

        protected override void Awake()
        {
            base.Awake();

            animancer = GetComponent<AnimancerComponent>();
            forcer = GetComponent<CharacterControllerForcer>();

            healthPoint.Init();            
            Animator = new Animator(animancer);            
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
            SpawnDestroyFX();
            SpawnExpOrb();
            Destroy(this.gameObject);
        }

        private IEnumerator CountAttackCoolTime()
        {
            IsAttackable = false;

            yield return new WaitForSeconds(attackData.AttackCoolTime);

            IsAttackable = true;
        }

        private void SpawnDestroyFX()
        {
            Instantiate(destructionFXPrefab, ActorParts.GetPart(EActorPart.Middle), Quaternion.identity);
        }

        private void SpawnExpOrb()
        {
            var expOrb = Instantiate(expOrbPrefab, ActorParts.GetPart(EActorPart.Middle), Quaternion.identity).GetComponent<ExpOrb>();
            expOrb.ExpAmount = 3.0f;
        }

        protected void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackData.AttackRange);

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(AttackData.AttackTrans.position, attackData.AttackRadius);
        }
    }
}