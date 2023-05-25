using System.Collections;
using System.Collections.Generic;
using TS.PageSlider;
using UnityEngine;

public class OnActivateResetBackToStart : MonoBehaviour
{
    [SerializeField] private PageScroller scroller = null;

    public void OnEnable()
    {
        scroller?.OverrideToPage(0);
    }
}
