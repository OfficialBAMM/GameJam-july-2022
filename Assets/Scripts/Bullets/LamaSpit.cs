using UnityEngine;

public class LamaSpit : BasicProjectile
{
    [SerializeField] private float shotSpeed;
    [SerializeField] private float damage = 0.1f;
    private Vector2 playerPos;

    private void Start()
    {
        GameObject player = GlobalVariableContainer.Instance.GetPlayer();
        playerPos = player.transform.position;
    }

    private void Update()
    {
        MoveTowardsPlayerPosition();
    }

    private void MoveTowardsPlayerPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos, shotSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventManager.StartPlayerGotHitEvent(damage);
            Destroy(gameObject);
        }
    }
}