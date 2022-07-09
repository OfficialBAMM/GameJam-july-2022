using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    PostProcessVolume volume;
    private Vignette vignette;
    [SerializeField] float vignetteStartingValue = 0.1f;
    [SerializeField] float vignetteEndingValue = 1;
    [SerializeField] float vignetteSpeed = 0.51f;   

    private void OnEnable()
    {
        EventManager.gameInterrupted += ActivateVignet;
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vignette);
        vignette.intensity.value = 0;
        Invoke("StartEvent", 30);
    }

    private void OnDisable()
    {
        EventManager.gameInterrupted -= ActivateVignet;
    }

    private void Update()
    {
        
    }

    public void ActivateVignet()
    {
        vignette.intensity.value = 0.4f;
    }

    public void StartEvent()
    {
        EventManager.GameIsInterrupted();
    }
}
