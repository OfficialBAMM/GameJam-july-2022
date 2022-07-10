using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class RepairDream : MonoBehaviour
{
    private PostProcessVolume volume;
    private Vignette vignette;

    private float survivalRestorePoints = 0.1f;
    private float healPerSecond;

    private bool dreamIsBeingRepaired = false;
    private float endingValue;

    #region EventManager

    private void OnEnable()
    {
        EventManager.destroyDreamEvent += StopHealing;
        EventManager.continueDreaming += HealDream;
    }

    private void OnDisable()
    {
        EventManager.destroyDreamEvent -= StopHealing;
        EventManager.continueDreaming -= HealDream;
    }

    #endregion EventManager

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vignette);
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
    }

    public void StopHealing()
    {
        dreamIsBeingRepaired = false;
    }

    public void HealDream()
    {
        endingValue = vignette.intensity.value - survivalRestorePoints;
        dreamIsBeingRepaired = true;
    }
}