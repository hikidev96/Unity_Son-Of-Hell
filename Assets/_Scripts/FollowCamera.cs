using UnityEngine;
using Cinemachine;
using DG.Tweening;

namespace SOD
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera followCamera;
        [SerializeField] private PlayerTransformData playerTransformData;

        private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

        private void Awake()
        {
            cinemachineBasicMultiChannelPerlin = followCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void Start()
        {
            followCamera.Follow = playerTransformData.Get();
        }

        public void Shake(float power = 2.0f)
        {
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = power;

            DOTween.To(() => cinemachineBasicMultiChannelPerlin.m_AmplitudeGain, (x) => cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = x, 0.0f, 0.2f);
        }
    }
}
