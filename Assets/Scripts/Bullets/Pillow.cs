using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : BasicProjectile
{
    private int dmg = 11;
    private float degreesPerSecond = 20;
    private bool enemyHit = false;

    private BoxCollider2D boxCollider;
    private AudioSource audioShoot;

    private void Start()
    {
        base.Start();
        boxCollider = GetComponent<BoxCollider2D>();
        audioShoot = GetComponent<AudioSource>();

        PlayAudio();

        degreesPerSecond = Random.Range(50, 100) * rb.velocity.magnitude;
    }

    private void Update()
    {
        base.Update();

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
        rb.gravityScale = 4f;

        if (rb.velocity.x > 0)
            rb.velocity = Vector2.left;
        else
            rb.velocity = Vector2.right;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BasicEnemy enemy = collision.rigidbody.GetComponentInParent<BasicEnemy>();

        if (enemy)
        {
            enemyCollision();
            enemy.GotHit(dmg);
        }
    }

    void PlayAudio()
    {
        audioShoot.pitch = Random.Range(0.8f, 1.2f);
        audioShoot.Play();
    }
}