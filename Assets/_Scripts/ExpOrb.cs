using UnityEngine;

namespace SOD
{
    public class ExpOrb : Orb
    {
        public float ExpAmount = 0.0f;

        [SerializeField] private Rigidbody rb;
        [SerializeField] private SphereCollider sc;

        private Player player;
        private bool isGrounded;

        private void Awake()
        {
            player = FindObjectOfType<Player>();
        }

        public void Start()
        {
            var randomDir = new Vector3(Random.Range(-1.0f, 1.0f), 1.0f, Random.Range(-1.0f, 1.0f));
            var randomPower = Random.Range(3.0f, 7.0f);
            rb.AddForce(randomDir * randomPower, ForceMode.Impulse);
        }

        private void FixedUpdate()
        {
            if (player != null && isActivated == true && isGrounded == true)
            {
                var dirTowardPlayer = (player.GetActorPart(EActorPart.Middle) - this.transform.position).normalized;
                rb.MovePosition(rb.position + (dirTowardPlayer * Time.deltaTime * 15.0f));
            }
        }

        public override void Activate()
        {
            if (isActivated == true)
            {
                return;
            }

            isActivated = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground") == true)
            {
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                isGrounded = true;

                this.transform.position = new Vector3(this.transform.position.x, other.transform.position.y + sc.radius, this.transform.position.z);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") == true && isGrounded == true)
            {
                other.GetComponent<Player>().ExpBehaviour.AddExp(ExpAmount);
                DestroySelf();
            }
        }
    }
}