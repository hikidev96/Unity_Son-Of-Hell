using UnityEngine;

namespace SOD
{
    public class Frost : Projectile
    {
        protected override void Awake()
        {
            base.Awake();

            speed = 8.0f;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();            
        }

        protected override void Hit(HitBox hitBox)
        {
            base.Hit(hitBox);

            if (hitBox.GameActor.gameObject.GetComponent<Chill>() == null)
            {
                hitBox.GameActor.gameObject.AddComponent<Chill>();
            }            
        }
    }
}
