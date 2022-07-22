using UnityEngine;
using Sirenix.OdinInspector;

namespace SOD
{
    public class GameActor : MonoBehaviour
    {
        [SerializeField, BoxGroup("Base")] private ActorParts actorParts;

        public ActorParts ActorParts => actorParts;

        protected virtual void Awake()
        {
            
        }
    }
}