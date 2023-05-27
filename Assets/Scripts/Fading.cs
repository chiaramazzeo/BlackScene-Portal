using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public float fadeDuration = 1.0f;
    public float delay = 1.0f;

    private bool isImage1Faded = false;
    private bool isImage2Faded = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        if (!isImage1Faded)
        {
            yield return StartCoroutine(FadeRawImage(image1, true)); // Fade in the first image

            // Wait for the fade-in to finish
            yield return new WaitForSeconds(delay);

            yield return StartCoroutine(FadeRawImage(image1, false)); // Fade out the first image

            // Wait for the fade-out to finish
            yield return new WaitForSeconds(delay);

            isImage1Faded = true;
        }

        if (!isImage2Faded && isImage1Faded)
        {
            // Activate the second image
            image2.gameObject.SetActive(true);

            yield return StartCoroutine(FadeRawImage(image2, true)); // Fade in the second image

            // Wait for the fade-in to finish
            yield return new WaitForSeconds(delay);

            yield return StartCoroutine(FadeRawImage(image2, false)); // Fade out the second image

            isImage2Faded = true;
        }
    }

    private IEnumerator FadeRawImage(Image targetImage, bool fadeIn)
    {
        float elapsedTime = 0.0f;
        Color imageColor = targetImage.color;
        float startAlpha = fadeIn ? 0.0f : 1.0f;
        float endAlpha = fadeIn ? 1.0f : 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            imageColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            targetImage.color = imageColor;
            yield return null;
        }
    }
}