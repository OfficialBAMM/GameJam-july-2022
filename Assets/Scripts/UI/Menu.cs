using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool menuVisible = true;
    [SerializeField] private GameObject menuItems;
    [SerializeField] private GameObject startOfGameItems;
    [SerializeField] private GameObject endOfGameItems;

    private void OnEnable()
    {
        EventManager.pauseGameEvent += ToggleMenu;
        EventManager.resumeGameEvent += ToggleMenu;
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        CheckInput();
    }

    private void OnDisable()
    {
        EventManager.pauseGameEvent -= ToggleMenu;
        EventManager.resumeGameEvent -= ToggleMenu;
    }

    private void CheckInput()
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

    private void ToggleMenu()
    {
        if (menuVisible)
        {
            menuItems.SetActive(false);
            menuVisible = false;
            Time.timeScale = 1;
        }
        else
        {
            menuItems.SetActive(true);
            menuVisible = true;
            Time.timeScale = 0;
        }
    }
}