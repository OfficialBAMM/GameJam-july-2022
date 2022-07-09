using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEyeLid : MonoBehaviour
{
    [SerializeField] private Animator animator;

    #region EventManager

    private void OnEnable()
    {
        EventManager.dreamIsBeingDestroyed += openEyeLid;
        EventManager.dreamResumed += closeEyeLid;
    }

    private void OnDisable()
    {
        EventManager.dreamIsBeingDestroyed -= openEyeLid;
        EventManager.dreamResumed += closeEyeLid;
    }

    #endregion EventManager

    private void openEyeLid()
    {
        animator.SetBool("OpenLid", true);
    }

    private void closeEyeLid()
    {
        animator.SetBool("OpenLid", false);
    }
}