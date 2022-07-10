using UnityEngine;

public class LightSwitch: MonoBehaviour
{
    private bool lightIsOn = false;
    [SerializeField] GameObject startScreen;

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

    public void TurnOffLight()
    {
        if (lightIsOn)
        {
            EventManager.ResumeDream();
            lightIsOn = false;
        }
    }

    public void ResumeGame()
    {
        EventManager.StartResumeGameEvent();
    }

    public void HideStartScreen()
    {
        EventManager.StartResumeGameEvent();
        startScreen.SetActive(false);
    }
}