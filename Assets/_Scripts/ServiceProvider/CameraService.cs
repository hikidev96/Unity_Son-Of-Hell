using UnityEngine;

namespace SOD
{
    public class CameraService : MonoBehaviour
    {
        private FollowCamera followCamera;

        private void Awake()
        {
            followCamera = FindObjectOfType<FollowCamera>();
        }

        public void Shake()
        {
            if (followCamera == null)
            {
                return;
            }
        }
    }
}