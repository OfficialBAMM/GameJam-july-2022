using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject StartScreen;

    #region EventManager

    private void OnEnable()
    {
        EventManager.gameOverEvent += ShowStartScreenFunc;
    }

    private void OnDisable()
    {
        EventManager.gameOverEvent -= ShowStartScreenFunc;
    }

    #endregion EventManager

    public void ShowStartScreenFunc()
    {
        // Yikes. Couldn't make a better restart function right before the end of the gamejam.
        StartScreen.SetActive(true);
        Invoke(nameof(RestartScene), 0.4f);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}