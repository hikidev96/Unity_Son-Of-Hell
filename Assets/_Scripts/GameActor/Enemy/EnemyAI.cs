using UnityEngine;
using Pathfinding;

namespace SOD
{
    [RequireComponent(typeof(Seeker))]   
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private PlayerTransformData playerTransformData;

        private Seeker seeker;

        private void Awake()
        {
            seeker = GetComponent<Seeker>();
        }

        public void CalculatePath(OnPathDelegate callback)
        {
            seeker.StartPath(this.transform.position, playerTransformData.Get().position, callback);
        }

        public bool PlayerIsInRange(float range)
        {
            return Vector3.Distance(this.transform.position, playerTransformData.Get().position) <= range;
        }
    }
}