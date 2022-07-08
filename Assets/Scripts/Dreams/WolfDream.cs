using UnityEngine;

public class WolfDream : BasicDream
{
    [SerializeField] private float speed;

    public override float GetSleepTime()
    {
        return 4f;
    }

    public override void Shoot()
    {
        GameObject bullet = Instantiate(this.bullet, bulletSpawnPoint);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        bullet.GetComponent<Rigidbody2D>().velocity = lookPos.normalized * speed;
    }
}