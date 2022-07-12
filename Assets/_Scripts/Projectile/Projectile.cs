using UnityEngine;

namespace SOD
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected GameObject destroyFX;

        protected float speed = 5.0f;
        protected Rigidbody rb;

        private GameObjectLifeTimer lifeTimer;

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

        }

        protected virtual void FixedUpdate()
        {

        }

        protected virtual void OnDisable()
        {
            lifeTimer.OnLifeOver.RemoveListener(DestrySelf);
        }

        protected virtual void DestrySelf()
        {
            SpawnDestroyFX();
            Destroy(this.gameObject);
        }

        private void SpawnDestroyFX()
        {
            Instantiate(destroyFX, this.transform.position, Quaternion.identity);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("EnemyHitBox"))
            {
                other.gameObject.GetComponent<HitBox>().Hit(new HitData(new DamageData(5)));
                DestrySelf();
            }
        }
    }
}
