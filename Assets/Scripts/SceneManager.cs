using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private GameObject player;

    private bool gameIsInterrupted;

    public static SceneManager Instance { get; private set; }

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

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
        if (gameObjects.Length != 1)
        {
            Debug.LogError("Motherfucker u forgot the Player tag on the player, or there are multiple. I dunno what is worse tbh. Or I mean if u want multiplayer u do u.");
            return;
        }

        this.player = gameObjects[0];
    }

    public GameObject GetPlayer()
    {
        return this.player;
    }
}