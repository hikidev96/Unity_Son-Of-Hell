using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace SOD
{
    public class DamageData
    {
        public float Damage { get; private set; }

        public DamageData(float damage)
        {
            this.Damage = damage;
        }
    }

    [System.Serializable]
    public class HealthPoint
    {
        [SerializeField] protected float maxHP;

        public float CurrentHP { get; protected set; }
        public UnityEvent OnDie { get; private set; } = new UnityEvent();
        public bool IsDead { get; private set; }

        public virtual void Damage(DamageData damageData)
        {
            if (IsDead == true)
            {
                return;
            }

            CurrentHP -= damageData.Damage;

            if (CurrentHP <= 0.0f)
            {
                IsDead = true;
                OnDie.Invoke();
            }
        }

        public virtual void Init()
        {
            OnDie = new UnityEvent();
            CurrentHP = maxHP;
        }
    }
}