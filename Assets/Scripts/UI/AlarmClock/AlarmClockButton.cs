using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClockButton : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (!animator)
        {
            Debug.LogError("AlarmClockButton doesn't have animator coupled");
        }
    }

    public void PlayAnimation()
    {
        animator.SetTrigger("Pressed");
    }
}