using UnityEngine;

public class LamaSpit : BasicProjectile
{
    [SerializeField] private float shotSpeed;
    [SerializeField] private float damage = 1;
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
}