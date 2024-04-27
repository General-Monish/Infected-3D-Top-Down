using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //[SerializeField] public Image timerImage;
    //[SerializeField] private GameObject clockImg;
    //[SerializeField] private GameObject ObjecticePanel;
    //[HideInInspector] public float maxTimer = 8f;
    //[HideInInspector] public bool TimerReachedZero = false;

    //public static Timer Instance;

    //public delegate void TimerFinshed();

    //public event TimerFinshed OnTimerFished;

    //private Coroutine timerCoroutine;

    //private void Start()
    //{
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    // Start the timer coroutine
    //    timerCoroutine = StartCoroutine(CountDownTimer());
    //}

    //private IEnumerator CountDownTimer()
    //{
    //    float elapsedTime = 0f;

    //    while (elapsedTime < maxTimer)
    //    {
    //        yield return null; // Wait for the next frame

    //        elapsedTime += Time.deltaTime; // Increment elapsed time by time passed since last frame

    //        // Update the fill amount of the timer image
    //        timerImage.fillAmount = 1f - (elapsedTime / maxTimer); // Invert fill amount to show countdown effect
    //    }

    //    // Timer has reached zero, handle the event (e.g., deactivate UI elements)
    //    if (OnTimerFished != null)
    //    {
    //        OnTimerFished.Invoke();
    //    }
    //    else
    //    {
    //        Debug.LogWarning("No event handlers attached to OnTimerFished event.");
    //    }

    //    ObjecticePanel.SetActive(false);
    //    clockImg.SetActive(false);
    //}

    //public void ResetTimer()
    //{
    //    // Stop the timer coroutine if it's running
    //    if (timerCoroutine != null)
    //        StopCoroutine(timerCoroutine);

    //    // Restart the timer coroutine
    //    timerCoroutine = StartCoroutine(CountDownTimer());
    //}

    //private void OnDisable()
    //{
    //    // Stop the timer coroutine when the script is disabled
    //    if (timerCoroutine != null)
    //        StopCoroutine(timerCoroutine);
    //}
}
