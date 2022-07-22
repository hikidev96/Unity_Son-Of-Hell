using UnityEngine;

namespace SOD
{
    [CreateAssetMenu(menuName = "SOD/PlayerData/TransformData")]
    public class PlayerTransformData : ScriptableObject
    {
        private Transform playerTrans;        

        public Transform Get()
        {
            return playerTrans;
        }

        public void Set(Transform transform)
        {
            this.playerTrans = transform;
        }
    }
}