using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace SOD.UI
{
    public class HandCardUI : CardUI
    {
        [SerializeField] private TextMeshProUGUI handNameTextMesh;
        [SerializeField] private TextMeshProUGUI handDescriptionTextMesh;

        private HandData handData;        

        public void SetHandData(HandData handData)
        {
            this.handData = handData;
            handNameTextMesh.text = handData.HandName;
            handDescriptionTextMesh.text= handData.HandDescription; 
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            var player = FindObjectOfType<Player>();
            player.HandController.SetHandPrefab(handData.HandPrefab);
        }
    }
}