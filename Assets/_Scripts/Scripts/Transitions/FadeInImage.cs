using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour
{
    public Image buttonImage;
    public float fadeInTime = 1f;

    private float alpha = 0f;
    private bool isFadingIn = false;

    async void Start()
    {
        buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, alpha);
        await Task.Delay(6000);
        isFadingIn = true;
    }

    void Update()
    {
        if (isFadingIn)
        {
            alpha += Time.deltaTime / fadeInTime;
            buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, alpha);

            if (alpha >= 1f)
            {
                isFadingIn = false;
            }
        }
    }
}
