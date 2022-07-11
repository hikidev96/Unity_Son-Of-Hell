using UnityEngine;

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
        [SerializeField] private float maxHP;        

        public float CurrentHP { get; private set; }
        public bool IsDead { get; private set; }

        public HealthPoint(float maxHP)
        {
            this.maxHP = maxHP;

            Init();            
        }

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
            }
        }

        private void Init()
        {
            CurrentHP = maxHP;
        }
    }
}