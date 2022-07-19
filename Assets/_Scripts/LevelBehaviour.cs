using UnityEngine;

namespace SOD
{
    public class LevelBehaviour : MonoBehaviour
    {
        [SerializeField] private ExpBehaviour expBehaviour;
        [SerializeField] private PlayerLevelData playerLevelData;

        private void Awake()
        {
            expBehaviour.OnFull.AddListener(LevelUp);
        }

        public void LevelUp()
        {
            playerLevelData.Level += 1;
        }
    }
}
