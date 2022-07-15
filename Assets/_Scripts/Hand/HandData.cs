using UnityEngine;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/HandData")]
    public class HandData : ScriptableObject
    {
        [SerializeField] private string handName;
        [SerializeField] private string handDescription;
        [SerializeField] private GameObject handPrefab;

        public string HandName => handName;
        public string HandDescription => handDescription;
        public GameObject HandPrefab => handPrefab;
    }
}