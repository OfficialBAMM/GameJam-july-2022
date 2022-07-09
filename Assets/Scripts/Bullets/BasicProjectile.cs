using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicProjectile : MonoBehaviour
{
    [SerializeField]
    private float timeToDespawnBullet = 5f;

    protected Rigidbody2D rb;

    protected void Start()
    {
        Invoke(nameof(DeleteProjectile), timeToDespawnBullet);
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
    }

    protected void DeleteProjectile()
    {
        Destroy(gameObject);
    }
}