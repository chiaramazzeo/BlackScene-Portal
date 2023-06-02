using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    public Image firstImage;
    public Image secondImage;
    public GameObject[] gameObjectsToActivate;
    public GameObject[] gameObjectsToDeactivate;
    public Toggle toggle;
    public float fadeDuration = 1f;

    private bool isFading = false;
    private int clickCount = 0;

    void Start()
    {
        toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggle);
        });
    }

    void ToggleValueChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            clickCount = 0;
            firstImage.gameObject.SetActive(true);
            secondImage.gameObject.SetActive(false);
        }
        else
        {
            firstImage.gameObject.SetActive(false);
            secondImage.gameObject.SetActive(false);

            // Deactivate game objects
            foreach (GameObject gameObject in gameObjectsToDeactivate)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (toggle.isOn && Input.GetMouseButtonDown(0) && !isFading)
        {
            clickCount++;
            StartCoroutine(FadeInImage());

            if (clickCount >= 2)
            {
                firstImage.gameObject.SetActive(false);
                secondImage.gameObject.SetActive(false);

                foreach (GameObject gameObject in gameObjectsToActivate)
                {
                    gameObject.SetActive(true);
                }
            }
        }
    }

    private System.Collections.IEnumerator FadeInImage()
    {
        isFading = true;

        secondImage.gameObject.SetActive(true);

        Color imageColor = secondImage.color;
        imageColor.a = 0f;
        secondImage.color = imageColor;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;

            imageColor.a = Mathf.Lerp(0f, 1f, normalizedTime);
            secondImage.color = imageColor;

            yield return null;
        }

        imageColor.a = 1f;
        secondImage.color = imageColor;

        isFading = false;
    }
}
