using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    private UnityEngine.Rendering.VolumeProfile volume;
    private UnityEngine.Rendering.Universal.Vignette vignette;

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
        EventManager.destroyDreamEvent += ActivateVignet;
        EventManager.continueDreaming += DisableVignet;
    }

    private void OnDisable()
    {
        EventManager.destroyDreamEvent -= ActivateVignet;
        EventManager.continueDreaming -= DisableVignet;
    }

    #endregion EventManager

    private void Start()
    {
        volume = GetComponent<UnityEngine.Rendering.Volume>()?.profile;
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