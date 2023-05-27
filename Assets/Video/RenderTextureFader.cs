using UnityEngine;
using UnityEngine.UI;

public class RenderTextureFader : MonoBehaviour
{
    public RawImage rawImage;
    public RenderTexture renderTexture;
    public float duration = 2f;
    public AnimationCurve fadeCurve;

    private float startTime;
    private bool fadingOut;

    private void Start()
    {
        startTime = Time.time;
        rawImage.texture = renderTexture;
        rawImage.color = Color.white;
        fadingOut = false;
    }

    private void Update()
    {
        float elapsed = Time.time - startTime;
        if (elapsed >= duration && !fadingOut)
        {
            StartCoroutine(FadeOut());
        }
    }

    private System.Collections.IEnumerator FadeOut()
    {
        fadingOut = true;

        float elapsedTime = 0f;
        Color startColor = rawImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            float fadeValue = fadeCurve.Evaluate(t);
            rawImage.color = Color.Lerp(startColor, endColor, fadeValue);
            yield return null;
        }

        rawImage.color = endColor;
        rawImage.texture = null;
        Destroy(renderTexture);

        Destroy(gameObject);
    }
}
