using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    private PostProcessVolume volume;
    private Vignette vignette;

    private bool dreamIsBeingDestroyed = false;

    [SerializeField] private float vignetteStartingValue = 0.1f;
    [SerializeField] private float vignetteEndingValue = 1.3f;
    [SerializeField] private float lerpDuration = 5;
    [SerializeField] private float survivalRestorePoints = 0.3f;

    private float timeElapsed;
    private float valueToLerp;

    #region EventManager

    private void OnEnable()
    {
        EventManager.dreamIsBeingDestroyed += ActivateVignet;
        EventManager.dreamResumed += DisableVignet;
    }

    private void OnDisable()
    {
        EventManager.dreamIsBeingDestroyed -= ActivateVignet;
        EventManager.dreamResumed += DisableVignet;
    }

    #endregion EventManager

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vignette);
    }

    private void Update()
    {
        if (dreamIsBeingDestroyed)
        {
            if (timeElapsed < lerpDuration)
            {
                valueToLerp = Mathf.Lerp(vignetteStartingValue, vignetteEndingValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                vignette.intensity.value = valueToLerp;
            }
        }
    }

    public void ActivateVignet()
    {
        vignette.intensity.value = vignetteStartingValue;
        dreamIsBeingDestroyed = true;
    }

    public void DisableVignet()
    {
        if (dreamIsBeingDestroyed)
        {
            dreamIsBeingDestroyed = false;
            vignette.intensity.value -= survivalRestorePoints;
        }
    }
}