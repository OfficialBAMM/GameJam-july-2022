using UnityEngine;

public class BasicGun : MonoBehaviour
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform bulletSpawnPoint;

    protected float shootingCooldown = 0f;

    public void Update()
    {
        if (this.shootingCooldown > 0)
            this.shootingCooldown -= Time.deltaTime;
    }

    public virtual void Shoot()
    { }

    public bool allowedToShoot()
    {
        return this.shootingCooldown <= 0;
    }
}