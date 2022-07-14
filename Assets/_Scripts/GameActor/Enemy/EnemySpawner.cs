using System.Collections;
using UnityEngine;

namespace SOD
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject TEMP_enemyPrefab;

        private Player player;

        private void Awake()
        {
            player = FindObjectOfType<Player>();
        }

        private void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            if (player == null)
            {
                yield break;
            }

            while (true)
            {
                var randomDir = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f)).normalized;
                Instantiate(TEMP_enemyPrefab, player.transform.position + (randomDir * 45.0f), Quaternion.identity);
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}