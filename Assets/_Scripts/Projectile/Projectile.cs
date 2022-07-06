using UnityEngine;

namespace SOD
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected GameObject destroyFX;

        protected float speed = 5.0f;

        private GameObjectLifeTimer lifeTimer;

        protected virtual void Awake()
        {
            lifeTimer = GetComponent<GameObjectLifeTimer>();    
        }

        protected virtual void OnEnable()
        {
            lifeTimer.OnLifeOver.AddListener(SpawnDestroyFX);
        }

        protected virtual void Start()
        {
            
        }

        protected virtual void FixedUpdate()
        {

        }

        protected virtual void OnDisable()
        {
            lifeTimer.OnLifeOver.RemoveListener(SpawnDestroyFX);
        }

        private void SpawnDestroyFX()
        {
            Instantiate(destroyFX, this.transform.position, Quaternion.identity);
        }
    }
}
