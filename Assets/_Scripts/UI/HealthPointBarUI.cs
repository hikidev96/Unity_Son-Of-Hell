using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SOD
{
    public class HealthPointBarUI : MonoBehaviour
    {
        [SerializeField] private PlayerHealthPointData healthPointData;
        [SerializeField] private Image fillImage;
        [SerializeField] private Image whileBackGroundImage;
        [SerializeField] private TextMeshProUGUI expTextMesh;

        private void Update()
        {
            fillImage.fillAmount = healthPointData.CurrentHp / healthPointData.MaxHp;

            if (whileBackGroundImage.fillAmount > fillImage.fillAmount)
            {
                whileBackGroundImage.fillAmount -= Time.deltaTime * 0.2f;
            }

            expTextMesh.text = $"{((int)healthPointData.CurrentHp).ToString()}/{((int)healthPointData.MaxHp).ToString()}";
        }
    }
}
