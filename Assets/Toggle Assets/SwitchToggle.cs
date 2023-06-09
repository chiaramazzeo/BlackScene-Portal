using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;
    [SerializeField] Sprite secondSprite;

    Image backgroundImage, handleImage;
    Color backgroundDefaultColor, handleDefaultColor;
    Sprite handleDefaultSprite;

    Toggle toggle;

    Vector2 handlePosition;

    // Start is called before the first frame update
    void Awake()
    {
        toggle = GetComponent<Toggle>();
        handlePosition = uiHandleRectTransform.anchoredPosition;

        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;

        handleDefaultSprite = handleImage.sprite;

        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
        {
            OnSwitch (true);
        }

    }

    void OnSwitch(bool on)
    {
        uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1: handlePosition;
        
        backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor;

        handleImage.color = on ? handleActiveColor : handleDefaultColor;

        handleImage.sprite = on ? secondSprite : handleDefaultSprite;
     
        
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
