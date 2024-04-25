using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader 
{
    public enum Scene
    {
        MM,
        LD,
        Game,
        Game2,
        Game3
    }

    public static Scene targetScene;

    public static void Load(Scene targetScene)
    {
        SceneLoader.targetScene = targetScene;

        SceneManager.LoadScene(Scene.LD.ToString());

        
    }

    public static void LoaderCallBack()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
