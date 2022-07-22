using UnityEngine;

namespace SOD
{
    public enum EActorPart
    {
        Top,
        Middle,
        Bottom,
    }

    public class ActorParts : MonoBehaviour
    {
        [SerializeField] private Vector3 topOffset;
        [SerializeField] private Vector3 middleOffset;
        [SerializeField] private Vector3 bottomOffset;

        public Vector3 GetPart(EActorPart actorPart)
        {
            if (actorPart == EActorPart.Top)
            {
                return this.transform.position + topOffset;
            }
            else if (actorPart == EActorPart.Middle)
            {
                return this.transform.position + middleOffset;
            }
            else if (actorPart == EActorPart.Bottom)
            {
                return this.transform.position + bottomOffset;
            }

            return Vector3.zero;
        }

        private void OnDrawGizmos()
        {
            var radious = 0.25f;
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(this.transform.position + topOffset, radious);
            Gizmos.DrawWireSphere(this.transform.position + middleOffset, radious);
            Gizmos.DrawWireSphere(this.transform.position + bottomOffset, radious);
        }
    }
}