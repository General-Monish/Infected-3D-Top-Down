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

    private void Start()
    {
        mainMenuPanel.SetActive(true);
    }
    public void PlayButton()
    {
        SceneLoader.Load(SceneLoader.Scene.Game);
    }

    public void BackButtonToMainMenu()
    {

        SettingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void CreditsButton()
    {
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
