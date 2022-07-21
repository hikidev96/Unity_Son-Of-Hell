using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SOD
{
    public class DashUI : MonoBehaviour
    {
        [SerializeField] private PlayerDashData playerDashData;
        [SerializeField] private Image fillImage;
        [SerializeField] private TextMeshProUGUI coolTimerTextMesh;

        private void Update()
        {
            var remainCoolTime = playerDashData.DashCoolTime - playerDashData.DashCoolTimer.Current;
            var dashCoolTime = playerDashData.DashCoolTime;

            fillImage.fillAmount = remainCoolTime / dashCoolTime;
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
