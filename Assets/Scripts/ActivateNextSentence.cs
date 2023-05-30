using UnityEngine;
using UnityEngine.UI;

public class ActivateNextSentence : MonoBehaviour
{
    public Image image;
    public float fadeDuration = 1f;

    private bool isFading = false;

    private void Start()
    {
        // Deactivate the image at the start
        image.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check for a mouse click
        if (Input.GetMouseButtonDown(0) && !isFading)
        {
            // Start the fade-in effect
            StartCoroutine(FadeInImage());
        }
    }

    private System.Collections.IEnumerator FadeInImage()
    {
        isFading = true;

        // Activate the image
        image.gameObject.SetActive(true);

        // Set the initial alpha to zero
        Color imageColor = image.color;
        imageColor.a = 0f;
        image.color = imageColor;

        // Perform the fade-in effect
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;

            // Update the alpha value gradually
            imageColor.a = Mathf.Lerp(0f, 1f, normalizedTime);
            image.color = imageColor;

            yield return null;
        }

        // Make sure the alpha is set to 1 at the end
        imageColor.a = 1f;
        image.color = imageColor;

        isFading = false;
    }
}

