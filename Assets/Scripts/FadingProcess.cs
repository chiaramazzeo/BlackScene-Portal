using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadingProcess : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Image image3;
    public float fadeDuration = 1.0f;
    public float delay = 1.0f;

    private bool isImage1Faded = false;
    private bool isImage2Faded = false;
    private bool isImage3Faded = false;
    private bool isFadingStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the fading process at the start
        DisableFadingProcess();
    }

    // Attach this method to the button's OnClick event in the Unity Inspector
    public void EnableFadingProcess()
    {
        // Start the fading process only if it hasn't started already
        if (!isFadingStarted)
        {
            isFadingStarted = true;
            StartCoroutine(FadeInAndOut());
        }
    }

    // Disable the fading process
    public void DisableFadingProcess()
    {
        StopAllCoroutines();
        isFadingStarted = false;
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

        if (!isImage3Faded && isImage2Faded)
        {
            // Activate the third image
            image3.gameObject.SetActive(true);

            StartCoroutine(FadeRawImage(image3, true)); // Start fading in the third and fourth images simultaneously

            // Wait for the fade-in to finish
            yield return new WaitForSeconds(fadeDuration);

            StartCoroutine(FadeRawImage(image3, false)); // Start fading out the third and fourth images simultaneously

            // Wait for the fade-out to finish
            yield return new WaitForSeconds(fadeDuration);


            isImage3Faded = true;
        }
    }

    private IEnumerator FadeTwoImages(Image image1, Image image2, bool fadeIn)
    {
        float elapsedTime = 0.0f;
        Color image1Color = image1.color;
        Color image2Color = image2.color;
        float startAlpha = fadeIn ? 0.0f : 1.0f;
        float endAlpha = fadeIn ? 1.0f : 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            image1Color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            image2Color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            image1.color = image1Color;
            image2.color = image2Color;
            yield return null;
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
