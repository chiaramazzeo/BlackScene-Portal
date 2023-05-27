using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageTransition : MonoBehaviour
{
    public RawImage rawImage;
    public Texture[] images;
    public float transitionDuration = 1.0f;
    public float delay = 1.0f;

    private int currentIndex = 0;

    private void Start()
    {
        StartCoroutine(TransitionImages());
    }

    private IEnumerator TransitionImages()
    {

            yield return StartCoroutine(FadeOutRawImage());
            yield return new WaitForSeconds(delay);

            currentIndex = (currentIndex + 1) % images.Length;
            rawImage.texture = images[currentIndex];

            yield return StartCoroutine(FadeInRawImage());
            yield return new WaitForSeconds(delay);

        //yield return StartCoroutine(FadeOutRawImage());
        //yield return new WaitForSeconds(delay);

    }

    private IEnumerator FadeInRawImage()
    {
        float elapsedTime = 0.0f;
        Color rawImageColor = rawImage.color;
        float startAlpha = 0.0f;
        float endAlpha = 1.0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);
            rawImageColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            rawImage.color = rawImageColor;
            yield return null;
        }

        rawImageColor.a = endAlpha;
        rawImage.color = rawImageColor;
    }

    private IEnumerator FadeOutRawImage()
    {
        float elapsedTime = 0.0f;
        Color rawImageColor = rawImage.color;
        float startAlpha = 1.0f;
        float endAlpha = 0.0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);
            rawImageColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            rawImage.color = rawImageColor;
            yield return null;
        }

        rawImageColor.a = endAlpha;
        rawImage.color = rawImageColor;
    }
}

