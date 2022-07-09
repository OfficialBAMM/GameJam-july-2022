using UnityEngine;

public class OpenEyeLid : MonoBehaviour
{
    [SerializeField] private Animator animator;

    #region EventManager

    private void OnEnable()
    {
        EventManager.destroyDreamEvent += openEyeLid;
        EventManager.continueDreaming += closeEyeLid;
    }

    private void OnDisable()
    {
        EventManager.destroyDreamEvent -= openEyeLid;
        EventManager.continueDreaming -= closeEyeLid;
    }

    #endregion EventManager

    private void openEyeLid()
    {
        animator.SetBool("OpenLid", true);
    }

    private void closeEyeLid()
    {
        animator.SetBool("OpenLid", false);
    }
}