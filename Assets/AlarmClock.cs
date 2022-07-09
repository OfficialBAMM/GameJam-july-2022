using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlarmClock : MonoBehaviour
{

    [SerializeField] Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation()
    {
        animator.SetTrigger("Pressed");
    }
}
