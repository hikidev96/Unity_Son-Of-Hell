using UnityEngine;

namespace SOD
{
    public class CardSelectorUI : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            ServiceProvider.GameService.Pause();
        }

        protected virtual void OnDisable()
        {
            ServiceProvider.GameService.Unpause();
        }
    }
}