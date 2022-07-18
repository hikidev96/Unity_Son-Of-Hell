using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace SOD
{
    public class Interaction : MonoBehaviour
    {
        private UnityEvent onInteract = new UnityEvent();

        public UnityEvent OnInteract => onInteract;

        [Button]
        public void Interact()
        {
            onInteract.Invoke();
        }
    }
}
