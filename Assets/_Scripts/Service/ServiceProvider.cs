using UnityEngine;

namespace SOD
{
    public class ServiceProvider : MonoBehaviour
    {
        public static InputService InputService;

        private void Awake()
        {
            InputService = FindObjectOfType<InputService>();    
        }
    }
}
