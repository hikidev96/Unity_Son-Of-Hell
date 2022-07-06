using UnityEngine;

namespace SOD
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private GameObject fireFXPrefab;
        [SerializeField] private GameObject projectilePrefab;        

        virtual public void DoAttack(Transform attackTrans)
        {
            SpawnFireFX(attackTrans);
            SpawnProjectile(attackTrans);
        }

        private void SpawnFireFX(Transform spawnTrans)
        {
            if (fireFXPrefab == null)
            {
                return;
            }

            Instantiate(fireFXPrefab, spawnTrans.position, spawnTrans.rotation);            
        }

        private void SpawnProjectile(Transform spawnTrans)
        {
            if (projectilePrefab == null)
            {
                return;
            }

            var projectileObj = Instantiate(projectilePrefab, spawnTrans.position, spawnTrans.rotation);
            var rotator = new Rotator(projectileObj.transform);
            rotator.RotateTowardMouse();
        }
    }
}
