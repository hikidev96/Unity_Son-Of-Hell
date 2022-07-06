using UnityEngine;
using UnityEngine.InputSystem;

namespace SOD
{
    public class PlayerAttackController : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Transform fireTrans;
        [SerializeField] private Attack attack;

        private void Awake()
        {
            ServiceProvider.InputService.OnNormalAttackKeyPress.AddListener(Attack);
        }

        private void OnDestroy()
        {
            ServiceProvider.InputService.OnNormalAttackKeyPress.RemoveListener(Attack);
        }

        public void Attack()
        {            
            if (attack == null)
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