using UnityEngine;

namespace SOD
{
    public class Player : GameActor
    {
        private Rotator rotator;

        protected override void Awake()
        {
            base.Awake();

            rotator = new Rotator(this.transform);
        }

        public void RotateSmoothly(Vector3 dir, bool considerCamera = false)
        {
            rotator.RotateSmoothly(dir, considerCamera);    
        }

        public void RotateDirectly(Vector3 dir, bool considerCamera = false)
        {
            rotator.RotateDirectly(dir, considerCamera);    
        }
    }
}