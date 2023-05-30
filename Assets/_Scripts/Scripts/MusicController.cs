using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource1;
    public AudioSource musicSource2;
    public float fadeDuration = 2f;

    private float startVolume1;
    private float startVolume2;
    public bool stopSecondSong = true;

    private void Start()
    {
        startVolume1 = musicSource1.volume;
        startVolume2 = musicSource2.volume;
        musicSource2.volume = 0f; // Set the initial volume of musicSource2 to 0
        //musicSource2.PlayDelayed(fadeDuration); // Start playing musicSource2 after the fade duration
        
    }

    public void StartFadeInAndOut()
    {
        stopSecondSong = false;
        StartCoroutine(FadeMusic());
    }

    private IEnumerator FadeMusic()
    {
        float timer = 0f;

        // Store the initial volumes
        float initialVolume1 = musicSource1.volume;
        float initialVolume2 = musicSource2.volume;

        // Fade out musicSource1
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;

            // Calculate the new volume for musicSource1
            float newVolume1 = Mathf.Lerp(initialVolume1, 0f, normalizedTime);

            // Update the volume of musicSource1
            musicSource1.volume = newVolume1;

            yield return null;
        }

        // Stop musicSource1 and reset its volume
        //musicSource1.Stop();
        //musicSource1.volume = startVolume1;
        

        // Fade in musicSource2
        timer = 0f; // Reset the timer

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;

            // Calculate the new volume for musicSource2
            float newVolume2 = Mathf.Lerp(0f, startVolume1, normalizedTime);

            // Update the volume of musicSource2
            musicSource2.volume = newVolume2;

            yield return null;
        }
    }

    public void StartFadeOutAndIn(){
        StartCoroutine(FadeInMusic());
        

    }

    private IEnumerator FadeInMusic()
    {
        float timer = 0f;

        // Store the initial volumes
        float initialVolume1 = musicSource1.volume;
        float initialVolume2 = musicSource2.volume;

        // Fade out musicSource2
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;

            // Calculate the new volume for musicSource1
            float newVolume2 = Mathf.Lerp(initialVolume2, 0f, normalizedTime);

            // Update the volume of musicSource2
            musicSource2.volume = newVolume2;

            yield return null;
        }

        // Stop musicSource1 and reset its volume
        //smusicSource2.Stop();
        //musicSource2.volume = startVolume2;

        // Fade in musicSource2
        timer = 0f; // Reset the timer

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;

            // Calculate the new volume for musicSource2
            float newVolume2 = Mathf.Lerp(0f, startVolume1, normalizedTime);

            // Update the volume of musicSource2
            musicSource1.volume = newVolume2;

            yield return null;
        }
    }
}



