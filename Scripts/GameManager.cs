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

    private void Awake()
    {
        tutorialPanel.SetActive(true);
        Instance = this;
    }

    private void Start()
    {
        pauseButton.SetActive(true);
    }

    private void Timer_OnTimerFinished()
    {
        pauseButton.SetActive(true);
    }

    public void ResumeBtn()
    {
        PauseButtonPanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseBtn()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        PauseButtonPanel.SetActive(true);
    }

    public void MainMenuBtn()
    {
        PauseButtonPanel.SetActive(false);
        SceneManager.LoadScene("MM");
    }

    public void NextBtn()
    {
        Time.timeScale = 1;
        tutorialPanel.SetActive(false);
    }
}
