using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float movementSpeed = 195f;

    private Vector2 input;

    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    public void FixedUpdate()
    {
        rb.velocity = input * movementSpeed * Time.fixedDeltaTime;
    }
}