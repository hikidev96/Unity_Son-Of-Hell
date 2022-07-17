using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace SOD.UI
{
    public class HandCardSelectorUI : CardSelectorUI
    {
        [SerializeField] private AnimationPlayer liquidAnimation;
        [SerializeField] private ScriptableObjectSet handDataSet;
        [SerializeField] private Transform cardParent;
        [SerializeField] private HandCardUI firstCard;
        [SerializeField] private HandCardUI secondCard;
        [SerializeField] private HandCardUI thirdCard;

        protected override void OnEnable()
        {
            base.OnEnable();

            firstCard.transform.localPosition = Vector3.zero;
            secondCard.transform.localPosition = Vector3.zero;
            thirdCard.transform.localPosition = Vector3.zero;

            firstCard.SetHandData(handDataSet.Get<HandData>());
            secondCard.SetHandData(handDataSet.Get<HandData>());
            thirdCard.SetHandData(handDataSet.Get<HandData>());

            firstCard.OnSelected.AddListener(() => StartCoroutine(PlayCloseAnimation(firstCard)));
            secondCard.OnSelected.AddListener(() => StartCoroutine(PlayCloseAnimation(secondCard)));
            thirdCard.OnSelected.AddListener(() => StartCoroutine(PlayCloseAnimation(thirdCard)));

            StartCoroutine(PlayOpenAnimation());
        }

        private IEnumerator PlayOpenAnimation()
        {
            cardParent.transform.localScale = Vector3.zero;
            cardParent.transform.DOScale(1.0f, 0.2f).SetUpdate(true).SetEase(Ease.InExpo);

            yield return new WaitForSecondsRealtime(0.4f);

            firstCard.transform.DOLocalMoveX(-600, 0.3f).SetUpdate(true).SetEase(Ease.InExpo);
            thirdCard.transform.DOLocalMoveX(+600, 0.3f).SetUpdate(true).SetEase(Ease.InExpo);
        }

        private IEnumerator PlayCloseAnimation(HandCardUI selectedCard)
        {
            if (firstCard != selectedCard) firstCard.FadeOut(0.2f);
            if (secondCard != selectedCard) secondCard.FadeOut(0.2f);
            if (thirdCard != selectedCard) thirdCard.FadeOut(0.2f);

            yield return new WaitForSecondsRealtime(0.5f);

            selectedCard.transform.DOLocalMoveX(0.0f, 0.3f).SetUpdate(true).SetEase(Ease.InExpo);
            liquidAnimation.Play(2.0f);

            yield return new WaitForSecondsRealtime(0.5f);

            selectedCard.transform.localScale = Vector3.one;
            selectedCard.transform.DOScale(0.0f, 0.2f).SetUpdate(true).SetEase(Ease.InExpo);            

            yield return new WaitForSecondsRealtime(0.2f);

            ServiceProvider.UIService.CloseCardSelector();
        }
    }
}