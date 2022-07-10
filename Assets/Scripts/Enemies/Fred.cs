using UnityEngine;

public class Fred : BasicEnemy
{
    private float distanceToPlayer;

    private void Start()
    {
        health = 10;
    }

    private void Update()
    {
        base.Update();
        distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);

        if (distanceToPlayer >= detectionDistance)
        {
            walkIdle();
            return;
        }

        if (distanceToPlayer >= minDistance)
        {
            walkToPlayer();
        }

        if (distanceToPlayer == minDistance)
        {
            AttackPlayer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    private void AttackPlayer()
    {
    }
}