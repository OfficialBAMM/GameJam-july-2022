using UnityEngine;

public class BasicGun : MonoBehaviour
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform bulletSpawnPoint;

    protected float shootingCooldown = 0f;

    public void Update()
    {
        if (shootingCooldown > 0)
            shootingCooldown -= Time.deltaTime;
    }

    public virtual void Shoot()
    { }

    public bool allowedToShoot()
    {
        return shootingCooldown <= 0;
    }
}