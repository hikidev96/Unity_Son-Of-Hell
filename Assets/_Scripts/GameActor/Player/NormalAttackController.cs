using UnityEngine;

namespace SOD
{
    public class NormalAttackController : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private Transform fireTrans;
        [SerializeField] private NormalAttack attack;

        public void TryAttack()
        {            
            if (attack == null)
            {
                return;
            }

            if (attack.IsReadyToFire == false)
            {
                return;
            }

            attack.DoAttack(fireTrans);
        }

        private void OnDrawGizmos()
        {
            if (fireTrans == null)
            {
                return;
            }

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(fireTrans.position, 0.3f);
        }
    }
}