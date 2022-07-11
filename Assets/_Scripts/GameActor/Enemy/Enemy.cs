using UnityEngine;

namespace SOD
{
    public class Enemy : GameActor, IDamageable
    {
        [SerializeField] private EnemyHealthPoint healthPoint;
        [SerializeField] private HitBox hitBox;
        [SerializeField] private Rigidbody rigidBody;

        protected override void Awake()
        {
            base.Awake();

            hitBox.OnHit.AddListener((hitData) => Damage(hitData.DamageData));
        }

        public virtual void Damage(DamageData damageData)
        {
            healthPoint.Damage(damageData);
        }
    }
}