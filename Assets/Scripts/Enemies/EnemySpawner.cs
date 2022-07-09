using System;
using System.Collections;
using System.Collections.Generic;
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
        Invoke(nameof(SpawnEnemy), secondsBetweenSpawns);
    }
}