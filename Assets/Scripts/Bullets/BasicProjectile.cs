using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicProjectile : MonoBehaviour
{
    [SerializeField]
    protected float timeToDespawnBullet = 1.5f;

    protected Rigidbody2D rb;

    private void Awake()
    {
        Invoke(nameof(DeleteProjectile), timeToDespawnBullet);
        rb = GetComponent<Rigidbody2D>();
    }

    protected void DeleteProjectile()
    {
        Destroy(gameObject);
    }
}