using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnLight : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Color dark;
    [SerializeField] Color light;

    private void OnEnable()
    {
        EventManager.lightEvent += TurnOnTheLight;
        EventManager.continueDreaming += TurnOffTheLight;
    }

    private void OnDisable()
    {
        EventManager.lightEvent -= TurnOnTheLight;
        EventManager.continueDreaming -= TurnOffTheLight;
    }


    void TurnOnTheLight()
    {
        image.color = light;
    }

    void TurnOffTheLight()
    {
        image.color = dark;
    }
}
