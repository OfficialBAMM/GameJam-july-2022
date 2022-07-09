using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action alarmEvent;
    public static event Action lightEvent;
    public static event Action continueDreaming;
    public static event Action destroyDreamEvent;


    public static void StartAlarmEvent()
    {
        alarmEvent?.Invoke();
        StartDestroyingDreamEvent();
    }

    public static void StartLightEvent()
    {
        lightEvent?.Invoke();
        StartDestroyingDreamEvent();
    }

    public static void ResumeDream()
    {
        continueDreaming?.Invoke();
    }

    public static void StartDestroyingDreamEvent()
    {
        destroyDreamEvent?.Invoke();
    }
}