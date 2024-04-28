using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingMangaer : MonoBehaviour
{
    public static LoadingMangaer Instance;

    public GameObject loadingScreenPanel;
    public Slider loadingSlider;

    private void Awake()
    {
        Instance = this;
    }

    public void SwitchToScreen(int index)
    {
        loadingScreenPanel.SetActive(true);
        loadingSlider.value = 0;
        StartCoroutine(SwitchToSceneAsync(index));
    }
    IEnumerator SwitchToSceneAsync(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);
        while(!asyncLoad.isDone)
        {
            loadingSlider.value = asyncLoad.progress;
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        loadingScreenPanel.SetActive(false);
    }
}
