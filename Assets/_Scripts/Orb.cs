using UnityEngine;
using Sirenix.OdinInspector;

namespace SOD
{
    public class Orb : MonoBehaviour
    {
        [SerializeField] private GameObject destryFXPrefab;

        [Button]
        public virtual void Activate()
        {
            Instantiate(destryFXPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}