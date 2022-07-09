using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : BasicProjectile
{
    private float degreesPerSecond = 20;
    private bool enemyHit = false;

    private BoxCollider2D boxCollider;

    private void Start()
    {
        base.Start();
        boxCollider = GetComponent<BoxCollider2D>();

        degreesPerSecond = Random.Range(50, 100) * rb.velocity.magnitude;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!enemyHit)
        {
            transform.Rotate(new Vector3(0, 0, -degreesPerSecond) * Time.deltaTime);
            return;
        }
    }

    private void enemyCollision()
    {
        boxCollider.enabled = false;
        enemyHit = true;
        Destroy(gameObject);
        rb.gravityScale = 2f;

        if (rb.velocity.x > 0)
            rb.velocity = Vector2.left;
        else
            rb.velocity = Vector2.right;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyCollision();
        }
    }
}