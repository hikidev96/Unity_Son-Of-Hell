using UnityEngine;

namespace SOD.UI
{
    public class CardSelectorUI : UIBehaviour
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