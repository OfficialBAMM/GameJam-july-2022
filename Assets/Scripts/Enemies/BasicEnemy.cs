using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BasicEnemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected BoxCollider2D boxCollider;

    [SerializeField] protected int health;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void GotHit(int dmg)
    {
        health -= dmg;
        if (health < 0)
        {
            boxCollider.enabled = false;
            rb.gravityScale = 2f;
            rb.velocity = Vector2.left * 2;
        }
    }
}