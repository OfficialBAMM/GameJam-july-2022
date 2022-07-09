using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BasicEnemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected BoxCollider2D boxCollider;
    protected GameObject player;

    [SerializeField] protected float minDistance = 3f;
    [SerializeField] protected float attackDistance = 4f;

    [SerializeField] protected float detectionDistance = 10f;
    [SerializeField] protected float moveSpeed = 2f;

    [SerializeField] protected int health;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        player = GlobalVariableContainer.Instance.GetPlayer();
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

    protected void walkIdle()
    {
        // TODO: Walk idly
    }

    protected void walkToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}