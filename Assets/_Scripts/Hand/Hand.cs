using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;

namespace SOD
{
    public class Hand : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.2f;
        [SerializeField] private GameObject fireFXPrefab;
        [SerializeField] private GameObject projectilePrefab;

        public Timer FireCoolTimer { get; private set; }
        public bool IsReadyToFire { get; private set; } = true;      
        public float FireRate => fireRate;

        private void Awake()
        {
            FireCoolTimer = new Timer();
        }

        virtual public void Fire(Transform attackTrans)
        {
            IsReadyToFire = false;

            SpawnFireFX(attackTrans);
            SpawnProjectile(attackTrans);
            StartCoolTimer();
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

        private void StartCoolTimer()
        {
            FireCoolTimer.StartTimer(fireRate, () => IsReadyToFire = true);
        }
    }
}