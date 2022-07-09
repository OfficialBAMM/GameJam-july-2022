using UnityEngine;

public class Fred : BasicEnemy
{
    [SerializeField] private float minDistance = 3f;
    [SerializeField] private float attackDistance = 4f;

    [SerializeField] private float detectionDistance = 10f;
    [SerializeField] private float moveSpeed = 2f;

    private GameObject player;
    private float distanceToPlayer;

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
        else if (distanceToPlayer == minDistance)
        {
            AttackPlayer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    private void walkIdle()
    {
        // TODO: Walk idly
    }

    private void walkToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
    }
}