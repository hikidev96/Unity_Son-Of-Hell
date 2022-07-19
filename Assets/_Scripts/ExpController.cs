using UnityEngine;

namespace SOD
{
    public class ExpController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Exp") == true)
            {
                other.GetComponent<ExpOrb>().Activate();
            }
        }
    }
}
