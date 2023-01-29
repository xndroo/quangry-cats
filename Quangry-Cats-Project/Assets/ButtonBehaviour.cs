using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour {

    public void OnMenuButtonPress()
    {
      SceneLoader.Load("Main Menu");
    }

    public void OnLevel1ButtonPress()
    {
      SceneLoader.Load("Andrew Scene");
    }

    public void OnLevel2ButtonPress()
    {
      SceneLoader.Load("Armored Scene");
    }
}
