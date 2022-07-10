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
        if (dreamIsBeingDestroyed)
        {
            vignette.intensity.value += damagePerSecond * Time.deltaTime;

            if (vignette.intensity.value >= 1)
            {
                EventManager.StartGameOverEvent();
            }
        }
    }

    private void PlayerGotHit(float dmg)
    {
        vignette.intensity.value += dmg;
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