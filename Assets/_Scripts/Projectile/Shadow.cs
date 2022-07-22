using UnityEngine;

namespace SOD
{
    public class Shadow : Projectile
    {
        protected override void Awake()
        {
            base.Awake();

            speed = 10.0f;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();            
        }

        protected override void Hit(HitBox hitBox)
        {
            base.Hit(hitBox);

            hitBox.GameActor.gameObject.AddComponent<Encroachment>();
        }
    }
}