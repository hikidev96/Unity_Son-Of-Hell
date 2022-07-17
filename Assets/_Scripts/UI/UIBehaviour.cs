using UnityEngine;
using DG.Tweening;

namespace SOD.UI
{
    public class UIBehaviour : MonoBehaviour
    {
        public void FadeOut(float duration)
        {
             var canvasGroup = GetComponent<CanvasGroup>();

            canvasGroup.DOFade(0.0f, duration).SetUpdate(true);
        }
    }
}
