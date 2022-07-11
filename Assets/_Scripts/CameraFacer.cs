using UnityEngine;

namespace SOD
{
    public class CameraFacer : MonoBehaviour
    {
        private void Update()
        {
            this.transform.forward = Camera.main.transform.forward; 
        }
    }
}
