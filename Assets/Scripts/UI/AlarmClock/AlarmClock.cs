using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
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
        EventManager.alarmEvent += AlarmGoesOff;
        EventManager.continueDreaming += AlarmStopped;
        animator = GetComponent<Animator>();
        alarmSound = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        EventManager.alarmEvent -= AlarmGoesOff;
        EventManager.continueDreaming -= AlarmStopped;
    }
    private void Update()
    {
        clockText.text = System.DateTime.Now.ToString("HH:mm");
    }

    private void AlarmGoesOff()
    {
        animator.SetTrigger("Alarm");
        alarmSound.Play();
    }

    private void AlarmStopped()
    {
        alarmSound.Stop();
        //animation stop
    }
}