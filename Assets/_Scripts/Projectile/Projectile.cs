using UnityEngine;

namespace SOD
{
    [RequireComponent(typeof(GameObjectLifeTimer), typeof(Rigidbody))]  
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected GameObject destructionFX;

        protected float speed = 5.0f;
        protected Vector3 forwardDir;
        protected Rigidbody rb;
        protected GameObjectLifeTimer lifeTimer;

        protected virtual void Awake()
        {
            lifeTimer = GetComponent<GameObjectLifeTimer>();
            rb = GetComponent<Rigidbody>(); 
        }

        protected virtual void OnEnable()
        {
            lifeTimer.OnLifeOver.AddListener(DestrySelf);
        }

        protected virtual void Start()
        {
            forwardDir = this.transform.forward;
        }

        protected virtual void FixedUpdate()
        {
            Move();
        }

        protected virtual void OnDisable()
        {
            lifeTimer.OnLifeOver.RemoveListener(DestrySelf);
        }

        protected virtual void Move()
        {
            rb.MovePosition(rb.position + forwardDir * speed * Time.deltaTime);
        }

        protected virtual void DestrySelf()
        {
            SpawnDestroyFX();
            Destroy(this.gameObject);
        }

        private void SpawnDestroyFX()
        {
            if (destructionFX == null)
            {
                return;
            }

            Instantiate(destructionFX, this.transform.position, Quaternion.identity);
        }

        protected virtual void Hit(HitBox hitBox)
        {
            hitBox.Hit(new HitData(new DamageData(5)));
            DestrySelf();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("EnemyHitBox"))
            {
                Hit(other.gameObject.GetComponent<HitBox>());
            }
        }
    }
}
