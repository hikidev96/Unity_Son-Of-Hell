using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace SOD.UI
{
    public class HandCardSelectorUI : CardSelectorUI
    {
        [SerializeField] private AnimationPlayer liquidAnimation_02;
        [SerializeField] private ScriptableObjectSet handDataSet;
        [SerializeField] private Transform cardParent;
        [SerializeField] private HandCardUI firstCard;
        [SerializeField] private HandCardUI secondCard;
        [SerializeField] private HandCardUI thirdCard;

        protected override void OnEnable()
        {
            base.OnEnable();

            InitCardPositions();
            SetHandDataToCards();
            AddListenerToCardSelectionEvent();
            DeactivateCardParent();

            StartCoroutine(PlayOpenAnimation());
        }

        private IEnumerator PlayOpenAnimation()
        {
            PlayLiquidAnimation_02();

            yield return new WaitForSecondsRealtime(0.5f);

            ShowCardParent();

            yield return new WaitForSecondsRealtime(0.5f);

            SplitUpSideCards();
        }

        private IEnumerator PlayCloseAnimation(HandCardUI selectedCard)
        {
            FadeOutUnSelectedCards(selectedCard);
            MoveSelectedCardToCenter(selectedCard);

            yield return new WaitForSecondsRealtime(0.3f);

            HideCardParent();

            yield return new WaitForSecondsRealtime(0.5f);

            ServiceProvider.UIService.CloseCardSelector();
        }

        private void InitCardPositions()
        {
            firstCard.transform.localPosition = Vector3.zero;
            secondCard.transform.localPosition = Vector3.zero;
            thirdCard.transform.localPosition = Vector3.zero;
        }

        private void SetHandDataToCards()
        {
            firstCard.SetHandData(handDataSet.Get<HandData>());
            secondCard.SetHandData(handDataSet.Get<HandData>());
            thirdCard.SetHandData(handDataSet.Get<HandData>());
        }

        private void AddListenerToCardSelectionEvent()
        {
            firstCard.OnSelected.AddListener(() => StartCoroutine(PlayCloseAnimation(firstCard)));
            secondCard.OnSelected.AddListener(() => StartCoroutine(PlayCloseAnimation(secondCard)));
            thirdCard.OnSelected.AddListener(() => StartCoroutine(PlayCloseAnimation(thirdCard)));
        }

        private void DeactivateCardParent()
        {
            cardParent.gameObject.SetActive(false);
        }

        private void HideCardParent()
        {
            cardParent.transform.localScale = Vector3.one;
            cardParent.transform.DOScale(0.0f, 0.2f).SetUpdate(true).SetEase(Ease.InExpo);
        }

        private void ShowCardParent()
        {
            cardParent.gameObject.SetActive(true);
            cardParent.transform.localScale = Vector3.zero;
            cardParent.transform.DOScale(1.0f, 0.2f).SetUpdate(true).SetEase(Ease.InExpo);
        }

        private void SplitUpSideCards()
        {
            firstCard.transform.DOLocalMoveX(-600, 0.3f).SetUpdate(true).SetEase(Ease.InExpo);
            thirdCard.transform.DOLocalMoveX(+600, 0.3f).SetUpdate(true).SetEase(Ease.InExpo);
        }

        private void FadeOutUnSelectedCards(HandCardUI selectedCard)
        {
            if (firstCard != selectedCard) firstCard.FadeOut(0.2f);
            if (secondCard != selectedCard) secondCard.FadeOut(0.2f);
            if (thirdCard != selectedCard) thirdCard.FadeOut(0.2f);
        }

        private void MoveSelectedCardToCenter(HandCardUI selectedCard)
        {
            selectedCard.transform.DOLocalMoveX(0.0f, 0.3f).SetUpdate(true).SetEase(Ease.InExpo);
        }

        private void PlayLiquidAnimation_02()
        {
            liquidAnimation_02.Play(1.5f);
        }
    }
}