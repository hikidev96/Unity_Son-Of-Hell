using UnityEngine;
using Pathfinding;

namespace SOD
{
    [RequireComponent(typeof(Seeker))]   
    public class EnemyAI : MonoBehaviour
    {
        private Seeker seeker;
        private Player player;

        private void Awake()
        {
            player = FindObjectOfType<Player>();

            seeker = GetComponent<Seeker>();
        }

        public void CalculatePath(OnPathDelegate callback)
        {
            seeker.StartPath(this.transform.position, player.transform.position, callback);
        }

        public bool PlayerIsInRange(float range)
        {
            return Vector3.Distance(this.transform.position, player.transform.position) <= range;
        }
    }
}
