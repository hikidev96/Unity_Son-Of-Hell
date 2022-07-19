using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace SOD
{
    public class ExpBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerExpData playerExpData;

        private UnityEvent onFull = new UnityEvent();

        public UnityEvent OnFull => onFull;

        [Button]
        public void AddExp(float expAmount)
        {
            playerExpData.CurrentExp += expAmount;

            if (playerExpData.CurrentExp >= playerExpData.MaxExp)
            {
                playerExpData.CurrentExp = 0.0f;
                playerExpData.MaxExp *= 1.2f;
                onFull.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Exp") == true)
            {
                other.GetComponent<ExpOrb>().Activate();
            }
        }
    }
}