using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistortedView : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.gameInterrupted += DistortView;
        EventManager.gameResumed += NormalizeView;
    }

    private void OnDisable()
    {
        EventManager.gameInterrupted -= DistortView;
        EventManager.gameResumed -= NormalizeView;
    }

    private void DistortView()
    {
    }

    private void NormalizeView()
    {
    }
}