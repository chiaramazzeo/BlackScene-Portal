using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;

public class ImageFadeOut : MonoBehaviour
{

    public RawImage imageToFade;
    public float fadeDuration = 1.0f;

    public async void Start()
    {
        imageToFade = GetComponent<RawImage>();
        await Task.Delay(4000);
        StartFadeOut();

    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0.0f;
        Color imageColor = imageToFade.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1.0f - (elapsedTime / fadeDuration);
            imageColor.a = alpha;
            imageToFade.color = imageColor;
            yield return null;
        }

        imageToFade.gameObject.SetActive(false);
    }
}
