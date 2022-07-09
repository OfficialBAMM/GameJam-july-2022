using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float secondsBetweenSpawns = 3;

    private void Start()
    {
        Invoke(nameof(SpawnEnemy), secondsBetweenSpawns);
    }

    private void SpawnEnemy()
    {
        GameObject enemy = GetRandomEnemy();
        GameObject spawnPoint = GetRandomSpawnPoint();

        if (enemy && spawnPoint)
        {
            Instantiate(enemy, spawnPoint.transform);
        }

        Invoke(nameof(SpawnEnemy), secondsBetweenSpawns);
    }

    private GameObject GetRandomEnemy()
    {
        int index = Random.Range(0, enemies.Length);
        return enemies[index];
    }

    private GameObject GetRandomSpawnPoint()
    {
        int index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index];
    }
}