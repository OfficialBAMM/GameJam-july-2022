using UnityEngine;

public class AlarmClockButton : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool alarmStarted = false;

    private void Awake()
    {
        if (!animator)
        {
            Debug.LogError("AlarmClockButton doesn't have animator coupled");
        }
    }

    public void PushedButton()
    {
        if (alarmStarted)
        {
            EventManager.ResumeDream();
            alarmStarted = false;
        }

        PlayAnimation();
    }

    public void PlayAnimation()
    {
        animator.SetTrigger("Pressed");
    }

    private void alarmStartedEvent()
    {
        alarmStarted = true;
    }

    private void OnEnable()
    {
        EventManager.alarmEvent += alarmStartedEvent;
    }

    private void OnDisable()
    {
        EventManager.alarmEvent -= alarmStartedEvent;
    }
}