using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackoutScreen : MonoBehaviour
{
    [SerializeField] private Image image;
    bool invisible = true;
    float transitionSpeed = 50f;

    private void OnEnable()
    {
        EventManager.pauseGameEvent += FadeIn;
        EventManager.resumeGameEvent += FadeOut;
    }

    private void Start()
    {
        //image = GetComponent<Image>();
    }

    private void Update()
    {
        Color color = image.color;

        if (invisible && color.a < 255)
        {
            color.a += transitionSpeed * Time.deltaTime;
            image.color = color;
        }

        if (!invisible && color.a > 0)
        {
            Debug.Log("make more visible");
            color.a -= transitionSpeed * Time.deltaTime;
            image.color = color;
        }
    }

    private void OnDisable()
    {
        EventManager.pauseGameEvent -= FadeIn;
        EventManager.resumeGameEvent -= FadeOut;
    }

    void FadeIn()
    {
        invisible = true;
        Debug.Log("YES INVISIBLIITYYYYY");
    }

    void FadeOut()
    {
        invisible = false;
        Debug.Log("NOOOOOOOOOOO INVISIBLIITYYYYY");
    }
}
