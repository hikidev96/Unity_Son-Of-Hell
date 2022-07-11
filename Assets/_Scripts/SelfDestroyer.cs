using UnityEngine;

namespace SOD
{
    public class SelfDestroyer : MonoBehaviour
    {
        public void DestroySelf()
        {
            Destroy(this.gameObject);
        }
    }
}
