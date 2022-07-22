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
        }

        protected override void Move()
        {   
            slowDownSpeed += Time.fixedDeltaTime * 20.0f;
            speed -= Time.fixedDeltaTime * slowDownSpeed;
            if (speed <= 0.0f)
                speed = 0.0f;            

            base.Move();
        }

        protected override void DestrySelf()
        {
            base.DestrySelf();

            var overappedColliders = Physics.OverlapSphere(this.transform.position, 2.0f);

            foreach (var overappedCollider in overappedColliders)
            {
                if (overappedCollider.CompareTag("EnemyHitBox") == true)
                {
                    overappedCollider.GetComponent<HitBox>().Hit(new HitData(new DamageData(3)));
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(this.transform.position, 2.0f);
        }
    }
}