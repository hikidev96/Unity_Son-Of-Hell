using UnityEngine;

namespace SOD.UI
{
    public class CardSelectorUI : UIBehaviour
    {
        [SerializeField] private AudioData openAudioData;

        protected virtual void OnEnable()
        {
            ServiceProvider.GameService.Pause();
            PlayOpenSound();
        }

        protected virtual void OnDisable()
        {
            ServiceProvider.GameService.Unpause();
        }

        protected void PlayOpenSound()
        {
            ServiceProvider.AudioService.Play(openAudioData);
        }
    }
}