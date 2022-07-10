using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackoutScreen : MonoBehaviour
{
    [SerializeField] private Image image;
    private bool invisible = true;
    private float transitionSpeed = .001f;

    private void OnEnable()
    {
        EventManager.pauseGameEvent += FadeIn;
        EventManager.gameOverEvent += FadeIn;
        EventManager.resumeGameEvent += FadeOut;
    }

    private void OnDisable()
    {
        EventManager.pauseGameEvent -= FadeIn;
        EventManager.gameOverEvent -= FadeIn;
        EventManager.resumeGameEvent -= FadeOut;
    }

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        Color color = image.color;

        if (invisible && color.a < 1)
        {
            color.a += (transitionSpeed * Time.unscaledTime);
            image.color = color;
        }

        if (!invisible && color.a > 0)
        {
            color.a -= transitionSpeed * Time.unscaledTime;
            image.color = color;
        }
    }

    private void FadeIn()
    {
        invisible = true;
    }

    private void FadeOut()
    {
        invisible = false;
    }
}