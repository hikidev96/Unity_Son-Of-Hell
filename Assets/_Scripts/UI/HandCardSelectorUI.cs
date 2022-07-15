using UnityEngine;

namespace SOD
{
    public class HandCardSelectorUI : CardSelectorUI
    {
        [SerializeField] private ScriptableObjectSet handDataSet;
        [SerializeField] private HandCardUI firstCard;
        [SerializeField] private HandCardUI secondCard;
        [SerializeField] private HandCardUI thirdCard;

        protected override void OnEnable()
        {
            base.OnEnable();

            firstCard.SetHandData(handDataSet.Get<HandData>());
            secondCard.SetHandData(handDataSet.Get<HandData>());
            thirdCard.SetHandData(handDataSet.Get<HandData>());
        }
    }
}