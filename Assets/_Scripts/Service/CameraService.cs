using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

namespace SOD
{
    public class CameraService : MonoBehaviour
    {
        [SerializeField] private VolumeProfile globalVolumeProfile;

        private FollowCamera followCamera;
        UnityEngine.Rendering.Universal.LensDistortion lensDistortion;
        UnityEngine.Rendering.Universal.Vignette vignette;
        UnityEngine.Rendering.Universal.DepthOfField dof;

        private void Awake()
        {
            globalVolumeProfile.TryGet(out lensDistortion);
            globalVolumeProfile.TryGet(out vignette);
            globalVolumeProfile.TryGet(out dof);
        }

        public void Shake(float power = 2.0f)
        {
            followCamera = GameObject.FindObjectOfType<FollowCamera>();

            if (followCamera == null)
            {
                return;
            }

            followCamera.Shake(power);
        }

        private void OnDestroy()
        {
            lensDistortion.intensity.value = 0.0f;
            vignette.intensity.value = 0.0f;
            dof.focalLength.value = 1.0f;
        }

        public void Damage()
        {
            StopAllCoroutines();
            StartCoroutine(PlayDamageEffect());
        }

        public void SetDepthOfField(float value)
        {
            dof.focalLength.value = value;
        }

        private IEnumerator PlayDamageEffect()
        {
            lensDistortion.intensity.value = 0.0f;
            vignette.intensity.value = 0.0f;

            DOTween.To(() => lensDistortion.intensity.value, (x) => lensDistortion.intensity.value = x, 0.5f, 0.1f);
            DOTween.To(() => vignette.intensity.value, (x) => vignette.intensity.value = x, 0.3f, 0.1f);

            yield return new WaitForSeconds(0.2f);

            DOTween.To(() => lensDistortion.intensity.value, (x) => lensDistortion.intensity.value = x, 0.0f, 0.5f);
            DOTween.To(() => vignette.intensity.value, (x) => vignette.intensity.value = x, 0.0f, 0.5f);
        }
    }
}