using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DestroyDream : MonoBehaviour
{
    private Volume volume;
    private Vignette vignette;

    private float damagePerSecond;
    private bool dreamIsBeingDestroyed = false;

    #region EventManager

    private void OnEnable()
    {
        EventManager.destroyDreamEvent += DestroyingDream;
        EventManager.continueDreaming += ContinueDreaming;
        EventManager.playerGotHitEvent += PlayerGotHit;
    }

    private void OnDisable()
    {
        EventManager.destroyDreamEvent -= DestroyingDream;
        EventManager.continueDreaming -= ContinueDreaming;
        EventManager.playerGotHitEvent -= PlayerGotHit;
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
        if (vignette.intensity.value >= 0.95)
        {
            EventManager.StartGameOverEvent();
            vignette.intensity.value = 0;
            GlobalVariableContainer.Instance.vignetteValue = vignette.intensity.value;
        }

        if (dreamIsBeingDestroyed)
        {
            vignette.intensity.value += damagePerSecond * Time.deltaTime;
            GlobalVariableContainer.Instance.vignetteValue = vignette.intensity.value;
        }
    }

    private void PlayerGotHit(float dmg)
    {
        vignette.intensity.value += dmg;
        GlobalVariableContainer.Instance.vignetteValue = vignette.intensity.value;
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