using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSoft;
    public AudioSource audioLoud;
    public AudioSource audioSad;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(audioSoft.clip);
        Debug.Log(audioLoud.clip);
        audioSoft.volume = 0f;
        audioLoud.volume = 0f;
        audioSad.Stop();
        audioSoft.Play();
        audioLoud.Play();
        FocusAudioSoft();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Focus soft");
            FocusAudioSoft();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Focus loud");
            FocusAudioLoud();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Focus sad");
            StartAudioSad();
        }

    }

    public void FocusAudioSoft()
    {
        StartCoroutine(StartFade(audioSoft, 1f, 1f));
        StartCoroutine(StartFade(audioLoud, 1f, 0f));
    }

    public void FocusAudioLoud()
    {
        StartCoroutine(StartFade(audioSoft, 1f, 0f));
        StartCoroutine(StartFade(audioLoud, 1f, 1f));
    }

    public void StartAudioSad()
    {
        StartCoroutine(StartFade(audioSoft, 1f, 0f));
        StartCoroutine(StartFade(audioLoud, 1f, 0f));
        audioSad.Play();
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}
