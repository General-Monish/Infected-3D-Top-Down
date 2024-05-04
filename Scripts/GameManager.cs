using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject PauseButtonPanel;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private GameObject tutorialPanel;
    [SerializeField]
    private GameObject playerPrefab;

    private void Awake()
    {
        playerPrefab.SetActive(false);
        tutorialPanel.SetActive(true);
        Instance = this;
    }

    private void Start()
    {
        pauseButton.SetActive(true);
    }

    public void ResumeBtn()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        playerPrefab.SetActive(true);
        PauseButtonPanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseBtn()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        playerPrefab.SetActive(false);
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        PauseButtonPanel.SetActive(true);
    }

    public void MainMenuBtn()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        PauseButtonPanel.SetActive(false);
        LoadingMangaer.Instance.SwitchToScreen(0);
        // nthng 
    }

    public void NextBtn()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        playerPrefab.SetActive(true);
        Time.timeScale = 1;
        tutorialPanel.SetActive(false);
    }
}
