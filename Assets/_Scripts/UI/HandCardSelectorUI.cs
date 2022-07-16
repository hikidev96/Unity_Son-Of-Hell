using UnityEngine;
using DG.Tweening;

namespace SOD
{
    public class HandCardSelectorUI : CardSelectorUI
    {
        [SerializeField] private ScriptableObjectSet handDataSet;
        [SerializeField] private Transform cardParent;
        [SerializeField] private HandCardUI firstCard;
        [SerializeField] private HandCardUI secondCard;
        [SerializeField] private HandCardUI thirdCard;

        protected override void OnEnable()
        {
            base.OnEnable();

            PlayOpenAnimation();

            firstCard.transform.localPosition = Vector3.zero;
            secondCard.transform.localPosition = Vector3.zero;
            thirdCard.transform.localPosition = Vector3.zero;

            firstCard.SetHandData(handDataSet.Get<HandData>());
            secondCard.SetHandData(handDataSet.Get<HandData>());
            thirdCard.SetHandData(handDataSet.Get<HandData>());
        }

        private void PlayOpenAnimation()
        {
            cardParent.transform.localScale = Vector3.zero;
            cardParent.transform.DOScale(1.0f, 0.2f).SetUpdate(true).onComplete += () =>
            {
                firstCard.transform.DOLocalMoveX(-600, 0.3f).SetUpdate(true).SetEase(Ease.InExpo);
                thirdCard.transform.DOLocalMoveX(+600, 0.3f).SetUpdate(true).SetEase(Ease.InExpo);
            };
        }
    }
}