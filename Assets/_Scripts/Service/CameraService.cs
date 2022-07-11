using UnityEngine;

namespace SOD
{
    public class CameraService : MonoBehaviour
    {
        private FollowCamera followCamera;
        
        public void Shake(float power = 2.0f)
        {
            followCamera = GameObject.FindObjectOfType<FollowCamera>();

            if (followCamera == null)
            {
                return;
            }

            followCamera.Shake(power);
        }
    }
}