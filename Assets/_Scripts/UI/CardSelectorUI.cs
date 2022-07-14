using UnityEngine;

namespace SOD
{
    public class CardSelectorUI : MonoBehaviour
    {
        private void OnEnable()
        {
            ServiceProvider.GameService.Pause();
        }

        private void OnDisable()
        {
            ServiceProvider.GameService.Unpause();
        }
    }
}