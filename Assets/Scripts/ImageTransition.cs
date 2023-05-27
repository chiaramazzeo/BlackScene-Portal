using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTransition : MonoBehaviour
{
    public Image image;
    public Sprite[] images;
    public float transitionDuration = 1.0f;
    public float delay = 1.0f;

    private int currentIndex = 0;

    private void Start()
    {
        StartCoroutine(TransitionImages());
    }

    private System.Collections.IEnumerator TransitionImages()
    {
            yield return StartCoroutine(FadeOutImage());
            yield return new WaitForSeconds(delay);

            currentIndex = (currentIndex + 1) % images.Length;
            image.sprite = images[currentIndex];

            yield return StartCoroutine(FadeInImage());
            yield return new WaitForSeconds(delay);

        //yield return StartCoroutine(FadeOutImage());
       // yield return new WaitForSeconds(delay);
    }

    private System.Collections.IEnumerator FadeInImage()
    {
        float elapsedTime = 0.0f;
        Color imageColor = image.color;
        float startAlpha = 0.0f;
        float endAlpha = 1.0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);
            imageColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            image.color = imageColor;
            yield return null;
        }

        imageColor.a = endAlpha;
        image.color = imageColor;
    }

    private System.Collections.IEnumerator FadeOutImage()
    {
        float elapsedTime = 0.0f;
        Color imageColor = image.color;
        float startAlpha = 1.0f;
        float endAlpha = 0.0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);
            imageColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            image.color = imageColor;
            yield return null;
        }

        imageColor.a = endAlpha;
        image.color = imageColor;
    }
}

