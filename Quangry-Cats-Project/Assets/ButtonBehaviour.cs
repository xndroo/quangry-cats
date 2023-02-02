using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {

    public void doExitGame() {
        Application.Quit();
    }

    public void OnLevel1ButtonPress()
    {
      SceneLoader.Load("Level 1");
    }

    public void OnLevel2ButtonPress()
    {
      SceneLoader.Load("Level 2");
    }
    public void OnLevel3ButtonPress()
    {
      SceneLoader.Load("Level 3");
    }
    public void OnLevel4ButtonPress()
    {
      SceneLoader.Load("Level 4");
    }
    public void OnLevel5ButtonPress()
    {
      SceneLoader.Load("Level 5");
    }
    public void OnLevel6ButtonPress()
    {
      SceneLoader.Load("Level 6");
    }
}
