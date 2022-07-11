using UnityEngine;
using UnityEngine.Events;

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

    public class HealthPoint : MonoBehaviour
    {
        [SerializeField] private float maxHP;
        [SerializeField] private UnityEvent<DamageData> onDamage = new UnityEvent<DamageData>();
        [SerializeField] private UnityEvent onDie = new UnityEvent();

        public float CurrentHP { get; private set; }
        public UnityEvent<DamageData> OnDamage => onDamage;
        public UnityEvent OnDie => onDie;

        private void Awake()
        {
            CurrentHP = maxHP;
        }

        public void Damage(DamageData damageData)
        {
            CurrentHP -= damageData.Damage;

            if (CurrentHP <= 0.0f)
            {
                onDie?.Invoke();
            }
            else
            {
                onDamage?.Invoke(damageData);
            }            
        }
    }
}