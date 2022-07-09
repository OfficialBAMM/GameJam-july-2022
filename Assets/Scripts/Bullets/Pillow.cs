using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : BasicProjectile
{
    private int dmg = 11;
    private float degreesPerSecond;
    private bool enemyHit = false;

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private ParticleSystem trail;
    private BoxCollider2D boxCollider;
    private AudioSource audioShoot;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        audioShoot = GetComponent<AudioSource>();

        PlayAudio();

        degreesPerSecond = Random.Range(50, 100) * rb.velocity.magnitude;
    }

    private void Update()
    {
        if (!enemyHit)
        {
            transform.Rotate(new Vector3(0, 0, -degreesPerSecond) * Time.deltaTime);
            return;
        }
    }

    private void destroyPillow()
    {
        boxCollider.enabled = false;
        enemyHit = true;

        trail.Stop();
        explosion.Play();
        sr.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BasicEnemy enemy = collision.gameObject?.GetComponentInParent<BasicEnemy>();
        if (enemy)
        {
            destroyPillow();
            enemy.GotHit(dmg);
        }
        else if (collision.gameObject.CompareTag("Level"))
        {
            destroyPillow();
        }
    }

    private void PlayAudio()
    {
        audioShoot.pitch = Random.Range(0.8f, 1.2f);
        audioShoot.Play();
    }
}