using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamaSpit : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float shotSpeed;
    [SerializeField] float despawnTime = 1.5f;
    [SerializeField] float damage = 1;
    Vector2 playerPos;

    private void Start()
    {
        player = SceneManager.Instance.GetPlayer();
        playerPos = player.transform.position;
        Destroy(gameObject, despawnTime);
    }

    private void Update()
    {
        MoveTowardsPlayerPosition();
    }

    void MoveTowardsPlayerPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos, shotSpeed * Time.deltaTime);
    }

 
}
