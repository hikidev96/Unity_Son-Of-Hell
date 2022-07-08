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
            this.transform.Translate(this.transform.forward * speed * Time.fixedDeltaTime, Space.World);
        }
    }
}
