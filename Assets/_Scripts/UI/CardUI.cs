using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace SOD.UI
{
    public class CardUI : UIBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private AudioData hoverAudioData;
        [SerializeField] private AudioData selectAudioData;

        public UnityEvent OnSelected { get; private set; } = new UnityEvent();

        virtual public void OnPointerClick(PointerEventData eventData)
        {
            OnSelected.Invoke();
            ServiceProvider.AudioService.Play(selectAudioData);
        }

        virtual public void OnPointerEnter(PointerEventData eventData)
        {
            this.transform.DOScale(1.1f, 0.2f).SetUpdate(true);
            ServiceProvider.AudioService.Play(hoverAudioData);
        }

        virtual public void OnPointerExit(PointerEventData eventData)
        {
            this.transform.DOScale(1.0f, 0.2f).SetUpdate(true);
        }
    }
}
