using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBulb : MonoBehaviour
{
    [SerializeField] Sprite imageLightOn;
    [SerializeField] Sprite imageLightOff;

    private Image imageSprite;


    private void OnEnable()
    {
        EventManager.lightEvent += TurnOnLight;
        EventManager.continueDreaming += TurnOffLight;
        EventManager.pauseGameEvent += TurnOnLight;
        EventManager.resumeGameEvent += TurnOffLight;
    }

    private void OnDisable()
    {
        EventManager.lightEvent -= TurnOnLight;
        EventManager.continueDreaming -= TurnOffLight;
        EventManager.pauseGameEvent -= TurnOnLight;
        EventManager.resumeGameEvent -= TurnOffLight;
    }

    private void Start()
    {
        imageSprite = GetComponent<Image>();
    }

    void TurnOnLight()
    {
        imageSprite.sprite = imageLightOn;
    }

    void TurnOffLight()
    {
        imageSprite.sprite = imageLightOff;
    }
}
