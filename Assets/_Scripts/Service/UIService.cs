using UnityEngine;
using Sirenix.OdinInspector;

namespace SOD
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private GameObject DamageUIPrefab;
        [SerializeField] private GameObject CardSelectorUIPrefab;

        private GameObject CardSelectorUIObj;

        public void SpawnDamageUI(DamageData damageData, Vector3 position)
        {
            var damageUIObj = Instantiate(DamageUIPrefab, position, Quaternion.identity);
            var damageUI = damageUIObj.GetComponent<UI.DamageUI>();

            damageUI.SetDamageData(damageData);
        }
        
        [Button]
        public void OpenCardSelector()
        {
            if (CardSelectorUIObj == null)
            {
                CardSelectorUIObj = Instantiate(CardSelectorUIPrefab);
            }

            CardSelectorUIObj.SetActive(true);
        }

        [Button]
        public void CloseCardSelector()
        {
            if (CardSelectorUIObj == null)
            {
                return;
            }

            CardSelectorUIObj.SetActive(false);
        }
    }
}
