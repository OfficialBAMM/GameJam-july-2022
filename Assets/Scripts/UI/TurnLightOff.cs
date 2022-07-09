using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightOff : MonoBehaviour
{
    private bool lightIsOn = false;

    private void OnEnable()
    {
        EventManager.lightEvent += EnableLightSwitch;
    }

    private void OnDisable()
    {
        EventManager.lightEvent -= EnableLightSwitch;
    }

    private void EnableLightSwitch()
    {
        lightIsOn = true;
    }

    public void DisableLightSwitch()
    {
        if (lightIsOn)
        {
            EventManager.ResumeDream();
            lightIsOn = false;
        }
    }
}