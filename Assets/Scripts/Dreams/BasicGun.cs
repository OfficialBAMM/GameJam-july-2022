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

    public virtual float GetSleepTime()
    { return 0f; }

    public virtual void Shoot()
    { }
}