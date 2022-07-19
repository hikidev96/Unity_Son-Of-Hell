using UnityEngine;
using Sirenix.OdinInspector;

namespace SOD
{
    public class Orb : MonoBehaviour
    {
        [SerializeField] private GameObject destryFXPrefab;
        [SerializeField] private AudioData destroyAudioData;

        protected bool isActivated;

        [Button]
        public virtual void Activate()
        {
            if (isActivated == true)
            {
                return;
            }

            isActivated = true;
            DestroySelf();
        }

        protected void SpawnDestroyFX()
        {
            if (destryFXPrefab == null)
            {
                return;
            }

            Instantiate(destryFXPrefab, this.transform.position, Quaternion.identity);
        }

        protected void PlayDestroyAudio()
        {
            if (destroyAudioData == null)
            {
                return;
            }

            ServiceProvider.AudioService.Play(destroyAudioData);
        }

        protected void DestroySelf()
        {
            SpawnDestroyFX();
            PlayDestroyAudio();
            Destroy(this.gameObject);
        }
    }
}