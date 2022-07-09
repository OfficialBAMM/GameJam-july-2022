using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float secondsBetweenSpawns = 3;

    // Update is called once per frame
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
            Debug.Log("spawn");
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