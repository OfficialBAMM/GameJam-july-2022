using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicBullet : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 direction;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move();
    }

    public void move()
    {
    }
}