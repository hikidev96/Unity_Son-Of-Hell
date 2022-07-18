using UnityEngine;
using Sirenix.OdinInspector;

namespace SOD
{
    public class Orb : MonoBehaviour
    {
        [SerializeField] private GameObject destryFXPrefab;
        [SerializeField] private Interaction interaction;

        private void Awake()
        {
            interaction.OnInteract.AddListener(Activate);
        }

        [Button]
        public virtual void Activate()
        {
            Instantiate(destryFXPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}