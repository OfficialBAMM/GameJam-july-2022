using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DestroyDream : MonoBehaviour
{
    private Volume volume;
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
        volume = GetComponent<Volume>();
        volume.profile.TryGet<Vignette>(out vignette);
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
        dreamIsBeingDestroyed = true;
    }

    public void ContinueDreaming()
    {
        dreamIsBeingDestroyed = false;
    }
}