using UnityEngine;

public class OpenEyeLid : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float sleepytime;

    private void Update()
    {
        animator.SetFloat("EyeState", GlobalVariableContainer.Instance.vignetteValue);
    }
}