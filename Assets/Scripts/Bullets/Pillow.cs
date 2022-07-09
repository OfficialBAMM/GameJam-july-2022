using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : BasicProjectile
{
    private float degreesPerSecond = 20;
    private bool enemyHit = false;

    private void Start()
    {
        degreesPerSecond = Random.Range(150, 500);
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
        enemyHit = true;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            enemyCollision();
        }
    }
}