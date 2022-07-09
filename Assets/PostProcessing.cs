using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessing : MonoBehaviour
{
    private PostProcessing postProcessing;

    private void OnEnable()
    {
        EventManager.gameInterrupted += ActivateVignet;
    }

    private void OnDisable()
    {
        EventManager.gameInterrupted -= ActivateVignet;
    }

    public void ActivateVignet()
    {

    }
}