using UnityEngine;
using System.Collections;

public class MaterialFader : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public float fadeSpeed = 0.5f;

    private bool isTransitionInProgress = false;

    public void OnToggleActiveStateChanged(bool isActive)
    {
        if (isActive && !isTransitionInProgress)
        {
            StartCoroutine(FadeToMaterial(material2));
        }
        else if (!isActive && !isTransitionInProgress)
        {
            StartCoroutine(FadeToMaterial(material1));
        }
    }

    IEnumerator FadeToMaterial(Material targetMaterial)
    {
        isTransitionInProgress = true;
        Color startingColor = GetComponent<Renderer>().material.color;
        Color targetColor = targetMaterial.color;
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime * fadeSpeed;
            GetComponent<Renderer>().material.color = Color.Lerp(startingColor, targetColor, t);
            yield return null;
        }
        isTransitionInProgress = false;
    }
}

