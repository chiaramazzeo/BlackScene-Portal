using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class CustomSliderGraphics : MonoBehaviour
{
    public Texture2D background;
    public Texture2D fill;
    public Texture2D handle;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.fillRect.gameObject.SetActive(false);
    }

    private void OnGUI()
    {
        float fillPercentage = slider.normalizedValue;

        if (background != null)
        {
            // Render background texture
            GUI.DrawTexture(new Rect(transform.position.x, transform.position.y, slider.GetComponent<RectTransform>().rect.width, slider.GetComponent<RectTransform>().rect.height), background);
        }

        if (fill != null)
        {
            // Render fill texture based on fillPercentage
            float fillWidth = fillPercentage * slider.GetComponent<RectTransform>().rect.width;
            GUI.DrawTexture(new Rect(transform.position.x, transform.position.y, fillWidth, slider.GetComponent<RectTransform>().rect.height), fill);
        }

        if (handle != null)
        {
            // Render handle texture
            float handlePosition = transform.position.x + fillPercentage * slider.GetComponent<RectTransform>().rect.width;
            float handleSize = 0.1f * slider.GetComponent<RectTransform>().rect.width;
            GUI.DrawTexture(new Rect(handlePosition - handleSize / 2, transform.position.y, handleSize, slider.GetComponent<RectTransform>().rect.height), handle);
        }
    }
}

