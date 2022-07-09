using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamaSpit : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float shotSpeed;

    private void Start()
    {
        player = SceneManager.Instance.GetPlayer();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, shotSpeed*Time.deltaTime);
    }
}
