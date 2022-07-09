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

    private void Awake()
    {
        Invoke(nameof(AlarmSetOff), 1);
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        clockText.text = System.DateTime.Now.ToString("HH:mm");
    }

    private void AlarmSetOff()
    {
        EventManager.GameIsInterrupted();
        animator.SetTrigger("Alarm");
    }
}