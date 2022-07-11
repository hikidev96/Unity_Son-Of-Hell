using UnityEngine;

namespace SOD
{
    public enum EActorPart
    {
        Top,
        Middle,
        Bottom,
    }

    [System.Serializable]
    public class ActorParts
    {
        [SerializeField] private GameActor actor;
        [SerializeField] private Vector3 topOffset;
        [SerializeField] private Vector3 middleOffset;
        [SerializeField] private Vector3 bottomOffset;

        public Vector3 GetPart(EActorPart actorPart)
        {
            if (actorPart == EActorPart.Top)
            {
                return actor.transform.position + topOffset;
            }
            else if (actorPart == EActorPart.Middle)
            {
                return actor.transform.position + middleOffset;
            }
            else if (actorPart == EActorPart.Bottom)
            {
                return actor.transform.position + bottomOffset;
            }

            return Vector3.zero;
        }

        public void DrawGizmo()
        {
            if (actor == null)
            {
                return;
            }

            var radious = 0.25f;
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(actor.transform.position + topOffset, radious);
            Gizmos.DrawWireSphere(actor.transform.position + middleOffset, radious);
            Gizmos.DrawWireSphere(actor.transform.position + bottomOffset, radious);
        }
    }
}
