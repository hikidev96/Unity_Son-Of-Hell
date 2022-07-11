using UnityEngine;

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
        public virtual void Hit(HitData hitData)
        {

        }
    }
}
