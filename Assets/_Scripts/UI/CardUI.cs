using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace SOD
{
    public class CardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        virtual public void OnPointerClick(PointerEventData eventData)
        {

        }

        virtual public void OnPointerEnter(PointerEventData eventData)
        {
            this.transform.DOScale(1.1f, 0.2f).SetUpdate(true);
        }

        virtual public void OnPointerExit(PointerEventData eventData)
        {
            this.transform.DOScale(1.0f, 0.2f).SetUpdate(true);
        }
    }
}
