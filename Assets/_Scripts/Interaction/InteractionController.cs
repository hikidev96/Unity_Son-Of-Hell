using UnityEngine;

namespace SOD
{
    public class InteractionController : MonoBehaviour
    {
        private Interaction interaction;

        private void Start()
        {
            ServiceProvider.InputService.OnInteractKeyPress.AddListener(TryInteract);
        }

        public void TryInteract()
        {
            if (interaction == null)
            {
                return;
            }

            interaction.Interact();
            interaction = null;
            ServiceProvider.UIService.HideInteractionUI();
        }

        private void OnTriggerEnter(Collider other)
        {

        }

        private void OnTriggerStay(Collider other)
        {
            var interaction = other.GetComponent<Interaction>();

            if (interaction != null)
            {
                this.interaction = interaction;
                ServiceProvider.UIService.ShowInteractionUI(other.transform.position);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var interaction = other.GetComponent<Interaction>();

            if (interaction != null)
            {
                this.interaction = null;
                ServiceProvider.UIService.HideInteractionUI();                
            }
        }
    }
}