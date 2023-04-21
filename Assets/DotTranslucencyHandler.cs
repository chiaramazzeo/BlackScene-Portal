using System.Collections;
using System.Collections.Generic;
using TS.PageSlider;
using UnityEngine;
using UnityEngine.UI;

public class DotTranslucencyHandler : MonoBehaviour
{
    [SerializeField] private PageDotsIndicator pageDotsIndicator = null;
    [SerializeField] private float deactivatedAlpha = 0.5f;
    [SerializeField] private float activatedAlpha = 1.0f;

    private void Start()
    {
        UpdateDotTranslucency(0);
    }

    public void OnPageChangedHandleDotTranslucency(PageContainer pageContainer) 
    {
        PageSlider pageSlider = GetComponent<PageSlider>();
        if (pageSlider)
        {
            for (int i = 0; i < pageSlider.pageContainers.Count; i++)
            {
                if (pageSlider.pageContainers[i] == pageContainer)
                {
                    UpdateDotTranslucency(i);
                    return;
                }
            }
        }
    }

    private void UpdateDotTranslucency(int activeDot)
    {
        for(int i = 0; i < pageDotsIndicator.pageDots.Count; i++)
        {
            float targetAlpha = deactivatedAlpha;
            if (i == activeDot)
            {
                targetAlpha = activatedAlpha;
            }

            Image imageComponent = pageDotsIndicator.pageDots[i].GetComponent<Image>();

            Color imageColor = imageComponent.color;
            imageColor.a = targetAlpha;
            imageComponent.color = imageColor;
        }
    }
}
