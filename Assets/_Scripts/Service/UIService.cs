using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace SOD
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private GameObject interactionUIPrefab;
        [SerializeField] private GameObject DamageUIPrefab;
        [SerializeField] private GameObject CardSelectorUIPrefab;

        private GameObject CardSelectorUIObj;
        private GameObject interactionUIObj;

        public void SpawnDamageUI(DamageData damageData, Vector3 position)
        {
            var damageUIObj = Instantiate(DamageUIPrefab, position, Quaternion.identity);
            var damageUI = damageUIObj.GetComponent<UI.DamageUI>();

            damageUI.SetDamageData(damageData);
        }

        public void ShowInteractionUI(Vector3 pos)
        {
            if (interactionUIObj == null)
            {
                interactionUIObj = Instantiate(interactionUIPrefab);
            }

            interactionUIObj.SetActive(true);
            interactionUIObj.transform.position = pos;
        }

        public void HideInteractionUI()
        {
            if (interactionUIObj == null)
            {
                return;
            }

            interactionUIObj.SetActive(false);
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
