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
        distanceToPlayer = Vector2.Distance(player.transform.position, this.transform.position);

        if (distanceToPlayer >= detectionDistance)
        {
            this.walkIdle();
            return;
        }

        if (distanceToPlayer >= minDistance)
        {
            this.walkToPlayer();
        }
        else if (distanceToPlayer == minDistance)
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