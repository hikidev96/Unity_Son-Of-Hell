using UnityEngine;
using Cinemachine;

namespace SOD
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera followCamera;

        private void Start()
        {
            var player = FindObjectOfType<Player>();
            if (player != null)
            {
                followCamera.Follow = player.transform;
            }
        }
    }
}
