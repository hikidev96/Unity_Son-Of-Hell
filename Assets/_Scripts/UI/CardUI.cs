using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace SOD.UI
{
    public class CardUI : UIBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public UnityEvent OnSelected { get; private set; } = new UnityEvent();

        virtual public void OnPointerClick(PointerEventData eventData)
        {
            OnSelected.Invoke();
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
