using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action gameInterrupted;

    public static event Action gameResumed;

    public static void GameIsInterrupted()
    {
        gameInterrupted?.Invoke();
    }

    public static void GameResumed()
    {
        gameInterrupted?.Invoke();
    }
}