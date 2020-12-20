using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject settingsPanel;

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
}
