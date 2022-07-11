using UnityEngine;

namespace SOD
{
    public class ServiceProvider : MonoBehaviour
    {
        public static InputService InputService;
        public static CameraService CameraService;

        private void Awake()
        {
            InputService = FindObjectOfType<InputService>();
            CameraService = FindObjectOfType<CameraService>();  
        }
    }
}
