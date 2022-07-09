using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 195f;
    [SerializeField] public List<GameObject> gunList;
    [SerializeField] private GameObject playerSprite;

    private GameObject activeGun;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Vector2 input;
    private bool isSleeping;
    private bool isWalking;
    private Animator animator;

    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = playerSprite.GetComponent<SpriteRenderer>();

        if (gunList[0])
        {
            activeGun = Instantiate(gunList[0]);
            activeGun.transform.SetParent(this.transform);
            activeGun.transform.position = this.transform.position;
        }
    }

    private void Update()
    {
        if (isSleeping)
            return;

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0))
        {
            if (activeGun)
            {
                activeGun.GetComponent<BasicGun>().Shoot();
            }
        }

        CheckForWalking();
        PlayAnimations();
    }

    public void FixedUpdate()
    {
        if (isSleeping)
            return;

        rb.velocity = input * movementSpeed * Time.fixedDeltaTime;
    }

    private void PlayAnimations()
    {
        animator.SetBool("IsWalking", isWalking);

        spriteRenderer.flipX = input.x < 0;
    }

    private void CheckForWalking()
    {
        isWalking = input.x != 0 || input.y != 0;
    }
}