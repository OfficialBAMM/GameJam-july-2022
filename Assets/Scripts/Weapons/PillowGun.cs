using UnityEngine;

public class PillowGun : BasicGun
{
    private float bulletSpeed = 10f;

    private readonly float firerate = 0.3f;

    public override void Shoot()
    {
        if (!base.allowedToShoot())
            return;

        base.shootingCooldown = firerate;

        GameObject bullet = Instantiate(this.bullet);
        Vector2 lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        bullet.transform.position = bulletSpawnPoint.position;

        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        bullet.GetComponent<Rigidbody2D>().velocity = lookPos.normalized * bulletSpeed;
    }
}