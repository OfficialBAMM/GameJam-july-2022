using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lama : BasicEnemy
{
    [Header("SpitBehaviour")]
    [SerializeField] private GameObject attackSpit;
    [SerializeField] private GameObject attackSpawnPoint;
    [SerializeField] private float timeBetweenSpit;

    [SerializeField] private float minDistance = 3f;
    [SerializeField] private float attackDistance = 4f;

    [SerializeField] private float detectionDistance = 10f;
    [SerializeField] private float moveSpeed = 2f;

    private GameObject player;
    private float distanceToPlayer;
    private bool isAttacking = false;

    private void Start()
    {
        player = SceneManager.Instance.GetPlayer();
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
        else if (distanceToPlayer <= minDistance)
        {
            AttackPlayer();
        }
    }

    private void walkIdle()
    {
        // TODO: Walk idly
    }

    private void walkToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Instantiate(attackSpit, attackSpawnPoint.transform.position, Quaternion.identity);
            StartCoroutine("AttackTimer");
        }
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(timeBetweenSpit);
        isAttacking = false;
    }
}