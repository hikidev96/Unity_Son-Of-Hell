using UnityEngine;

namespace SOD
{
    public class ServiceProvider : MonoBehaviour
    {
        public static InputService InputService;
        public static CameraService CameraService;
        public static UIService UIService;
        public static AudioService AudioService;
        public static GameService GameService;
        public static UnitService UnitService;

        private void Awake()
        {
            InputService = FindObjectOfType<InputService>();
            CameraService = FindObjectOfType<CameraService>();
            UIService = FindObjectOfType<UIService>();
            AudioService = FindObjectOfType<AudioService>();    
            GameService = FindObjectOfType<GameService>();
            UnitService = FindObjectOfType<UnitService>();  
        }
    }
}
