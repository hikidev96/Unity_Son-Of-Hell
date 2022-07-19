using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SOD.UI
{
    public class ExpBarUI : UIBehaviour
    {
        [SerializeField] private Image fillImage;
        [SerializeField] private PlayerExpData playerExpData;
        [SerializeField] private PlayerLevelData playerLevelData;
        [SerializeField] private TextMeshProUGUI expTextMesh;

        private void Update()
        {
            fillImage.fillAmount = playerExpData.CurrentExp / playerExpData.MaxExp;
            expTextMesh.text = $"{((int)playerExpData.CurrentExp).ToString()}/{((int)playerExpData.MaxExp).ToString()}";
        }
    }
}
