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

    private AudioSource audioSource;

    private static SceneM instance;

    private void Awake()
    {
       instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mainMenuPanel.SetActive(true);
    }


    public void PlayButton()
    {
        audioSource.Play();
        LoadingMangaer.Instance.SwitchToScreen(1);
    }

    public void BackButtonToMainMenu()
    {
        audioSource.Play();
        SettingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void CreditsButton()
    {
        audioSource.Play();
        Debug.Log("Credits button clicked");
        creditsPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }

    public void SettingsButton()
    {
        audioSource.Play();
        SettingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
