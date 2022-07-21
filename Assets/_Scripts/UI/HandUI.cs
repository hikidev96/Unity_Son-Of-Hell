using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SOD
{
    public class HandUI : MonoBehaviour
    {
        [SerializeField] private PlayerHandData playerHandData;
        [SerializeField] private Image fillImage;
        [SerializeField] private TextMeshProUGUI coolTimerTextMesh;

        private void Update()
        {
            if (playerHandData.Hand == null)
            {
                return;
            }

            var remainCoolTime = playerHandData.Hand.FireRate - playerHandData.Hand.FireCoolTimer.Current;
            var fireRate = playerHandData.Hand.FireRate;

            fillImage.fillAmount = remainCoolTime / fireRate;
            coolTimerTextMesh.text = $"{remainCoolTime:F1}";

            if (fillImage.fillAmount == 1.0f)
            {
                coolTimerTextMesh.alpha = 0.0f;
            }
            else
            {
                coolTimerTextMesh.alpha = 1.0f;
            }
        }
    }
}
