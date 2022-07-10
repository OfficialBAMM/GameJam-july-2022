using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DestroyDream : MonoBehaviour
{
    private PostProcessVolume volume;
    private Vignette vignette;

    private float damagePerSecond;

    // Dream is being destroyed variables
    private bool dreamIsBeingDestroyed = false;

    #region EventManager

    private void OnEnable()
    {
        EventManager.destroyDreamEvent += DestroyingDream;
        EventManager.continueDreaming += ContinueDreaming;
    }

    private void OnDisable()
    {
        EventManager.destroyDreamEvent -= DestroyingDream;
        EventManager.continueDreaming -= ContinueDreaming;
    }

    #endregion EventManager

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vignette);
        damagePerSecond = GlobalVariableContainer.Instance.damagePerSecond;
    }

    private void Update()
    {
        if (dreamIsBeingDestroyed)
        {
            vignette.intensity.value += damagePerSecond * Time.deltaTime;
        }
    }

    public void DestroyingDream()
    {
        //lerpStartingValue = vignette.intensity.value;
        //timeToLerp = 0f;
        //LerpDuration = remaingTimeLeft / vignette.intensity.value;

        dreamIsBeingDestroyed = true;
    }

    public void ContinueDreaming()
    {
        dreamIsBeingDestroyed = false;
    }
}