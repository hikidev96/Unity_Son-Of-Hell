using UnityEngine;

namespace SOD
{
    public class Bubble : Projectile
    {
        private float slowDownSpeed = 1.0f;

        protected override void Awake()
        {
            base.Awake();

            speed = 10.0f;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            //should change to rigidbody move from future
            slowDownSpeed += Time.fixedDeltaTime * 20.0f;
            speed -= Time.fixedDeltaTime * slowDownSpeed;
            if (speed <= 0.0f)
                speed = 0.0f;
            rb.MovePosition(rb.position + this.transform.forward * speed * Time.deltaTime);            
        }
    }
}
