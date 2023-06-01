using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    public GameObject toggleSwitch;
    public GameObject[] objectsToDisable;
    public GameObject firstImage;
    public GameObject secondImage;
    public GameObject[] objectsToEnable;

    private bool isToggleOn = false;

    public void OnToggleSwitch()
    {
        if (isToggleOn)
        {
            // Disable 3 game objects (2 images) with fade-in effect
            foreach (GameObject obj in objectsToEnable)
            {
                obj.SetActive(false);
                FadeIn(obj);
            }
            isToggleOn = false;
        }
        else
        {
            // Enable first image with quick fade-in effect
            firstImage.SetActive(true);
            FadeIn(firstImage);

            // Disable 4 game objects with quick fade-in effect
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
                FadeIn(obj);
            }
            isToggleOn = true;
        }
    }

    public void OnFirstImageClick()
    {
        // Enable second image with slower fade-in effect
        secondImage.SetActive(true);
        FadeInSlow(secondImage);
    }

    public void OnSecondImageClick()
    {
        // Disable both images and enable 3 game objects with fade-in effect
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
            FadeIn(obj);
        }
        secondImage.SetActive(false);
    }

    private void FadeIn(GameObject obj)
    {
        // Implement your fade-in effect for the object
        // For example, you can use the Unity UI CanvasGroup component to control the alpha value over time
        CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        // Implement your fade-in animation or tweening logic here
    }

    private void FadeInSlow(GameObject obj)
    {
        // Implement your slower fade-in effect for the object
        // For example, you can use the Unity UI CanvasGroup component to control the alpha value over time
        CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        // Implement your slower fade-in animation or tweening logic here
    }
}
