using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{

    public static void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static void Hello()
    {
        Debug.Log("hello");
    }
}
