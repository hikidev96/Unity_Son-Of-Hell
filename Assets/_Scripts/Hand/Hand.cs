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

        public int Level { get; private set; } = 1;
        public float Exp { get; private set; }
        public float GoalExp { get; private set; } = 50.0f;
        public bool IsReadyToFire { get; private set; } = true;
        
        [Button]
        public void AddEXP(float amountToAdd)
        {
            Exp += amountToAdd;

            if (Exp >= GoalExp)
            {
                LevelUp();                
                Exp = 0.0f;
            }
        }

        virtual public void Fire(Transform attackTrans)
        {
            SpawnFireFX(attackTrans);
            SpawnProjectile(attackTrans);
            StartCoroutine(WaitForReadyToFire());
        }

        virtual protected void LevelUp()
        {
            Debug.Log("Level UP!");
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