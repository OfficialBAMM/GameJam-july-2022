using UnityEngine;

public class BasicGun : MonoBehaviour
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform bulletSpawnPoint;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public virtual void Shoot()
    { }
}