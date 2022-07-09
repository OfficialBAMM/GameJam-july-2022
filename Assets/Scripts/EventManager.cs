using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action dreamIsBeingDestroyed;

    public static event Action dreamResumed;

    public static void DestroyDream()
    {
        dreamIsBeingDestroyed?.Invoke();
    }

    public static void ResumeDream()
    {
        dreamResumed?.Invoke();
    }
}