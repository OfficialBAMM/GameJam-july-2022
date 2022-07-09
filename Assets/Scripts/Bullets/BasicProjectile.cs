using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    [SerializeField]
    private float timeToDespawnBullet = 5f;

    private void Start()

    {
        Invoke(nameof(DeleteProjectile), timeToDespawnBullet);
    }

    private void Update()
    {
    }

    protected void DeleteProjectile()
    {
        Destroy(gameObject);
    }
}