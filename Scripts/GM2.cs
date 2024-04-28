using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM2 : MonoBehaviour
{
    public static GM2 Instance { get; private set; }

    [SerializeField]
    private GameObject PauseButtonPanel;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private GameObject playerPrefab;

    private void Awake()
    {
        playerPrefab.SetActive(false);
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
        playerPrefab.SetActive(true);
        PauseButtonPanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseBtn()
    {
        playerPrefab.SetActive(false);
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        PauseButtonPanel.SetActive(true);
    }

    public void MainMenuBtn()
    {
        PauseButtonPanel.SetActive(false);
        SceneManager.LoadScene("MM");
    }
}
