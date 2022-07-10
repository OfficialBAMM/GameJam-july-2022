using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class RepairDream : MonoBehaviour
{
    private Volume volume;
    private Vignette vignette;

    private float survivalRestorePoints = 0.1f;
    private float healPerSecond;

    private bool dreamIsBeingRepaired = false;
    private bool dreamIsBeingStarted = false;
    private float endingValue;

    #region EventManager

    private void OnEnable()
    {
        EventManager.destroyDreamEvent += StopHealing;
        EventManager.continueDreaming += HealDreamPartially;
    }

    private void OnDisable()
    {
        EventManager.destroyDreamEvent -= StopHealing;
        EventManager.continueDreaming -= HealDreamPartially;
    }

    #endregion EventManager

    private void Start()
    {
        Invoke(nameof(HealDreamCompletely), 2);
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
        healPerSecond = GlobalVariableContainer.Instance.damagePerSecond;
    }

    private void Update()
    {
        if (dreamIsBeingRepaired)
        {
            vignette.intensity.value -= healPerSecond * Time.deltaTime;
            if (vignette.intensity.value < endingValue)
            {
                dreamIsBeingRepaired = false;
            }
        }

        if (dreamIsBeingStarted)
        {
            vignette.intensity.value -= 0.5f * Time.deltaTime;
            if (vignette.intensity.value <= endingValue)
            {
                dreamIsBeingStarted = false;
            }
        }
    }

    public void StopHealing()
    {
        dreamIsBeingRepaired = false;
    }

    public void HealDreamPartially()
    {
        endingValue = vignette.intensity.value - survivalRestorePoints;
        dreamIsBeingRepaired = true;
    }

    public void HealDreamCompletely()
    {
        endingValue = 0;
        dreamIsBeingStarted = true;
    }
}