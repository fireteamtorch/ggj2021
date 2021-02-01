using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{

    public GameObject creditsAnchor;

    private void Start()
    {
        AudioManager.instance.StartAudioSad();
        creditsAnchor.SetActive(false);
    }

    public void ReportCreditsPressed()
    {
        creditsAnchor.SetActive(true);
    }

    public void ReportCreditsClosePressed()
    {
        creditsAnchor.SetActive(false);
    }

    public void ReportStartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
}
