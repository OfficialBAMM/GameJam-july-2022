using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action alarmEvent;

    public static event Action lightEvent;

    public static event Action continueDreaming;

    public static event Action destroyDreamEvent;

    public static event Action pauseGameEvent;

    public static event Action resumeGameEvent;

    public static event Action gameOverEvent;

    public static event Action<float> playerGotHitEvent;

    private float timeBetweenEvents = 10f;
    private float timeBeforNextEvent = 0;
    private bool eventIsRunning = false;

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

    public static void StartPlayerGotHitEvent(float dmg)
    {
        playerGotHitEvent?.Invoke(dmg);
    }

    public static void ResumeDream()
    {
        continueDreaming?.Invoke();
    }

    public static void StartDestroyingDreamEvent()
    {
        destroyDreamEvent?.Invoke();
    }

    public static void StartGameOverEvent()
    {
        gameOverEvent?.Invoke();
    }

    private void eventStoppedRunning()
    {
        eventIsRunning = false;
    }

    public static void StartPauseGameEvent()
    {
        pauseGameEvent?.Invoke();
    }

    public static void StartResumeGameEvent()
    {
        resumeGameEvent?.Invoke();
    }

    private void OnEnable()
    {
        EventManager.continueDreaming += eventStoppedRunning;
    }

    private void OnDisable()
    {
        EventManager.continueDreaming -= eventStoppedRunning;
    }

    private void Update()
    {
        if (eventIsRunning)
            return;

        if (timeBeforNextEvent > 0)
            timeBeforNextEvent -= Time.deltaTime;

        if (timeBeforNextEvent <= 0)
        {
            eventIsRunning = true;
            timeBeforNextEvent = timeBetweenEvents;
            increaseDifficulty();

            switch (UnityEngine.Random.Range(0, 2))
            {
                case 0:
                    StartAlarmEvent();
                    break;

                case 1:
                    StartLightEvent();
                    break;

                default:
                    break;
            }
        }
    }

    private void increaseDifficulty()
    {
        timeBetweenEvents -= 0.5f;
    }
}