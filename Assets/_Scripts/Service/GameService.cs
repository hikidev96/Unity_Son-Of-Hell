using UnityEngine;
using Sirenix.OdinInspector;

namespace SOD
{
    public class GameService : MonoBehaviour
    {
        [Button]
        public void Pause()
        {
            Time.timeScale = 0.0f;
        }

        [Button]
        public void Unpause()
        {
            Time.timeScale = 1.0f;
        }
    }
}