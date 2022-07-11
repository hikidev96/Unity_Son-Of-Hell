using UnityEngine;
using UnityEngine.Events;

namespace SOD
{
    public class HitData
    {
        public DamageData DamageData { get; private set; }

        public HitData(DamageData damageData)
        {
            DamageData = damageData;
        }
    }

    public class HitBox : MonoBehaviour
    {
        public UnityEvent<HitData> OnHit { get; private set; } = new UnityEvent<HitData>();

        public virtual void Hit(HitData hitData)
        {
            OnHit.Invoke(hitData);
        }
    }
}
