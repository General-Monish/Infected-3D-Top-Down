using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject creditsPanel;
    [SerializeField]
    private GameObject SettingsPanel;

    
    private static SceneM instance;

    private void Awake()
    {
       instance = this;
    }

    private void Start()
    {
        mainMenuPanel.SetActive(true);
    }


    public void PlayButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        LoadingMangaer.Instance.SwitchToScreen(1);
    }

    public void BackButtonToMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SettingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void CreditsButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        creditsPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }

    public void SettingsButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SettingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }
    public void QuitButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }
}
