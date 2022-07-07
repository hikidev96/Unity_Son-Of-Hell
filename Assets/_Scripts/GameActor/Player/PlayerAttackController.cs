using UnityEngine;

namespace SOD
{
    public class PlayerAttackController : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Transform fireTrans;
        [SerializeField] private Attack attack;

        private void Awake()
        {
            
        }

        private void OnDestroy()
        {
            
        }

        private void Update()
        {
            if (ServiceProvider.InputService.IsNormalAttackKeyPress == true)
            {
                TryAttack();
            }            
        }

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