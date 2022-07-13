using UnityEngine;

namespace SOD
{
    public class AudioPlayerOnStart : MonoBehaviour
    {
        [SerializeField] AudioData audioData;

        private void Start()
        {
            ServiceProvider.AudioService.Play(audioData);
        }
    }
}
