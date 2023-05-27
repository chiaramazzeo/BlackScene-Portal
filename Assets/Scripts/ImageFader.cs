using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    public Image Image;
    public float fadeDuration = 1.0f;
    public float delay = 1.0f;

    private void Start()
    {
        StartCoroutine(FadeInAndOut());
    }

    private System.Collections.IEnumerator FadeInAndOut()
    {
            yield return StartCoroutine(FadeRawImage(true));
            yield return new WaitForSeconds(delay);
            yield return StartCoroutine(FadeRawImage(false));
            yield return new WaitForSeconds(delay);
    }

    private System.Collections.IEnumerator FadeRawImage(bool fadeIn)
    {
        float elapsedTime = 0.0f;
        Color ImageColor = Image.color;
        float startAlpha = fadeIn ? 0.0f : 1.0f;
        float endAlpha = fadeIn ? 1.0f : 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            ImageColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            Image.color = ImageColor;
            yield return null;
        }

        ImageColor.a = endAlpha;
        Image.color = ImageColor;
    }
}
