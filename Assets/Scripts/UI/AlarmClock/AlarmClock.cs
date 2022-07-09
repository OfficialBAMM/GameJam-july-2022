using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AlarmClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private TextMeshProUGUI clockText;

    private Animator animator;
    private AudioSource alarmSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        alarmSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        clockText.text = System.DateTime.Now.ToString("HH:mm");
    }

    private void StartAlarm()
    {
        animator.SetTrigger("Alarm");
        alarmSound.Play();
    }

    private void StopAlarm()
    {
        alarmSound.Stop();
    }

    private void OnEnable()
    {
        EventManager.alarmEvent += StartAlarm;
        EventManager.continueDreaming += StopAlarm;
    }

    private void OnDisable()
    {
        EventManager.alarmEvent -= StartAlarm;
        EventManager.continueDreaming -= StopAlarm;
    }
}