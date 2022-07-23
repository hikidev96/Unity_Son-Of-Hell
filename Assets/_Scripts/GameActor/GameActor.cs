using UnityEngine;
using Sirenix.OdinInspector;

namespace SOD
{
    public class GameActor : MonoBehaviour
    {
        [SerializeField, BoxGroup("Base")] private ActorParts actorParts;

        public ActorParts ActorParts => actorParts;
        public Rotator Rotator { get; private set; }

        protected virtual void Awake()
        {
            Rotator = new Rotator(this.transform);
        }
    }
}