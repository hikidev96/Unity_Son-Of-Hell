using UnityEngine;

namespace SOD
{
    public class UnitService : MonoBehaviour
    {
        [SerializeField] private GameObject enemySpawnerPrefab;

        public void SpawnEnemySpawner()
        {
            Instantiate(enemySpawnerPrefab);
        }
    }
}
