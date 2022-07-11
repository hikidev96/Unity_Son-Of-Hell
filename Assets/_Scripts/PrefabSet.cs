using System.Collections.Generic;
using UnityEngine;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/PrefabSet")]
    public class PrefabSet : ScriptableObject
    {
        [SerializeField] private List<GameObject> prefabs;

        public GameObject Get()
        {
            return prefabs[Random.Range(0, prefabs.Count)];
        }
    }
}