using UnityEngine;

public class GlobalVariableContainer : MonoBehaviour
{
    private GameObject player;

    public float damagePerSecond = 0.1f;

    public float vignetteValue;

    public static GlobalVariableContainer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FindPlayer()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
        if (gameObjects.Length != 1)
        {
            Debug.LogError("Motherfucker u forgot the Player tag on the player, or there are multiple. I dunno what is worse tbh. Or I mean if u want multiplayer u do u.");
            return;
        }

        player = gameObjects[0];
    }

    public GameObject GetPlayer()
    {
        FindPlayer();

        return player;
    }
}