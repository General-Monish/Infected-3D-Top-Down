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
        LoadingMangaer.Instance.SwitchToScreen(1);
    }

    public void BackButtonToMainMenu()
    {

        SettingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void CreditsButton()
    {
        Debug.Log("Credits button clicked");
        creditsPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }

    public void SettingsButton()
    {
        SettingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
