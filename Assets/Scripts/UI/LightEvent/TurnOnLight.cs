using UnityEngine;
using UnityEngine.UI;

public class TurnOnLight : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Color dark;
    [SerializeField] private new Color light;

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

    private void TurnOnTheLight()
    {
        image.color = light;
    }

    private void TurnOffTheLight()
    {
        image.color = dark;
    }
}