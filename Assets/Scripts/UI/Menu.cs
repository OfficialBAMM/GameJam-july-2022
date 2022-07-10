using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool menuVisible = true;
    [SerializeField] GameObject menuButtons;

    private void OnEnable()
    {
        EventManager.pauseGameEvent += ToggleMenu;
        EventManager.resumeGameEvent += ToggleMenu;
    }

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.buildIndex != 0)
        {
            ToggleMenu();
        }

    }

    void Update()
    {
        CheckInput();
    }

    private void OnDisable()
    {
        EventManager.pauseGameEvent -= ToggleMenu;
        EventManager.resumeGameEvent -= ToggleMenu;
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuVisible)
            {
                EventManager.StartResumeGameEvent();
            }
            else
            {
                EventManager.StartPauseGameEvent();
            }
            
        }
    }

    void ToggleMenu()
    {
        if (menuVisible)
        {
            menuButtons.SetActive(false);
            menuVisible = false;
            Time.timeScale = 1;
        }
        else
        {
            menuButtons.SetActive(true);
            menuVisible = true;
            Time.timeScale = 0;
        }
    }
}
