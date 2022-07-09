using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 195f;
    [SerializeField] public List<GameObject> gunList;

    private Rigidbody2D rb;
    private Vector2 input;
    private bool isSleeping;

    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isSleeping)
            return;

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0))
        {
            if (gunList[0])
            {
                gunList[0].GetComponent<BasicGun>().Shoot();
            }
        }
    }

    public void FixedUpdate()
    {
        if (isSleeping)
            return;

        rb.velocity = input * movementSpeed * Time.fixedDeltaTime;
    }
}