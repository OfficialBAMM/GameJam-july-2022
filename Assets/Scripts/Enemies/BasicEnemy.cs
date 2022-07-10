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

    protected bool dead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        player = GlobalVariableContainer.Instance.GetPlayer();
    }

    protected void Update()
    {
        if (dead)
        {
            transform.Rotate(0f, 0f, 500f * Time.deltaTime);
        }
    }

    public void GotHit(int dmg)
    {
        health -= dmg;
        if (health < 0)
        {
            dead = true;
            boxCollider.enabled = false;
            rb.gravityScale = 2.5f;
            rb.velocity = Vector2.left * 2;
        }
    }

    protected void walkIdle()
    {
        // TODO: Walk idly
    }

    protected void walkToPlayer()
    {
        //move towards player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}