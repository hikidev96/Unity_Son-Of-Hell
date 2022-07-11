using UnityEngine;

namespace SOD
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private GameObject DamageUIPrefab;

        public void SpawnDamageUI(DamageData damageData, Vector3 position)
        {
            var damageUIObj = Instantiate(DamageUIPrefab, position, Quaternion.identity);
            var damageUI = damageUIObj.GetComponent<DamageUI>();

            damageUI.SetDamageData(damageData); 
        }
    }
}
