using System.Collections;
using System.Collections.Generic;
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
            rb.MovePosition(rb.position + this.transform.forward * speed * Time.deltaTime);
        }
    }
}
