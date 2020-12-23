using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{

    public GameObject settingsPanel;
    public AudioMixer mixer;

    void Start()
    {
        QuitSettings();
    }

    public void StartButton()
    {
        Debug.Log("Laduje gre...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Wychodze z gry...");
    }
    
    public void QuitSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("GenVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
