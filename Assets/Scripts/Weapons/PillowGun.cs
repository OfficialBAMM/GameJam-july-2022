using UnityEngine;

public class PillowGun : BasicGun
{
    [SerializeField] private float bulletSpeed;

    [SerializeField] private float lookPos;

    public override void Shoot()
    {
        GameObject bullet = Instantiate(this.bullet);
        Vector2 lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        bullet.transform.position = bulletSpawnPoint.position;

        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        bullet.GetComponent<Rigidbody2D>().velocity = lookPos.normalized * bulletSpeed;
    }
}