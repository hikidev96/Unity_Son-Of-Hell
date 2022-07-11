using UnityEngine;

namespace SOD
{
    public class GameActor : MonoBehaviour
    {
        [SerializeField] private ActorParts actorParts;

        protected virtual void Awake()
        {
            
        }
        
        public Vector3 GetActorPart(EActorPart actorPart)
        {
            return actorParts.GetPart(actorPart);  
        }

        protected virtual void OnDrawGizmos()
        {
            actorParts.DrawGizmo();
        }
    }
}