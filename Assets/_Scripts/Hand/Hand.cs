using System.Collections;
using UnityEngine;

namespace SOD
{
    public class Hand : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.2f;
        [SerializeField] private GameObject fireFXPrefab;
        [SerializeField] private GameObject projectilePrefab;

        public bool IsReadyToFire { get; private set; } = true;

        virtual public void Fire(Transform attackTrans)
        {
            SpawnFireFX(attackTrans);
            SpawnProjectile(attackTrans);            
            StartCoroutine(WaitForReadyToFire());
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

        private IEnumerator WaitForReadyToFire()
        {
            IsReadyToFire = false;
            yield return new WaitForSeconds(fireRate);
            IsReadyToFire = true;
        }
    }
}