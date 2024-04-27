using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject PauseButtonPanel;
    [SerializeField]
    public GameObject pauseButton;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        
        Timer.Instance.OnTimerFished += Timer_OnTimerFinished;
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
        SceneLoader.Load(SceneLoader.Scene.MM);
    }

}
