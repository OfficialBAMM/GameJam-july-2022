using System;
using UnityEngine;

public class BasicDream : MonoBehaviour
{
    [SerializeField] protected GameObject particle;
    [SerializeField] protected Transform particleSpawnPoint;
    [SerializeField] protected Transform particleDirection;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public virtual float Shoot()
    { return 0f; }
}