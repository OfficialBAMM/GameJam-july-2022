using System;
using UnityEngine;

public class Fred : MonoBehaviour
{
    [SerializeField] private float minDistance = 3f;
    [SerializeField] private float attackDistance = 4f;

    [SerializeField] private float detectionDistance = 10f;
    [SerializeField] private float moveSpeed = 2f;

    private GameObject player;
    private float distanceToPlayer;

    private void Start()
    {
        player = SceneManager.Instance.player;
    }

    private void Update()
    {
        distanceToPlayer = Vector2.Distance(player.transform.position, this.transform.position);
        Debug.Log(distanceToPlayer);

        if (distanceToPlayer >= detectionDistance)
        {
            this.walkIdle();
            return;
        }

        if (distanceToPlayer >= minDistance)
        {
            this.walkToPlayer();
        }
    }

    private void walkIdle()
    {
        Debug.Log("me is idle");
    }

    private void walkToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}