using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lama : BasicEnemy
{
    [Header("SpitBehaviour")]
    [SerializeField] private GameObject attackSpit;

    [SerializeField] private GameObject attackSpawnPoint;
    [SerializeField] private float timeBetweenSpit;

    private bool isAttacking = false;

    private void Start()
    {
        minDistance = 5f;
        health = 10;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(player.transform.position, this.transform.position);

        if (distanceToPlayer >= detectionDistance)
        {
            this.walkIdle();
            return;
        }

        if (distanceToPlayer >= minDistance)
        {
            this.walkToPlayer();
        }
        else if (distanceToPlayer <= minDistance)
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Instantiate(attackSpit, attackSpawnPoint.transform.position, Quaternion.identity);
            StartCoroutine("AttackTimer");
        }
    }

    private IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(timeBetweenSpit);
        isAttacking = false;
    }
}