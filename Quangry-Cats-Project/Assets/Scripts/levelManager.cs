using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject menuButton;
    public GameObject resetButton; 
    public GameObject PopupBG;
    public GameObject popupResetButton;
    public GameObject popupMenuButton;
    public GameObject popupNextButton;
    public GameObject popupWin;
    public GameObject popupLose;
    
    public bool levelOngoing = true;
    private GameObject playerManager;



    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager");

        GameObject myMenuButton = Instantiate(menuButton);
        GameObject myResetButton = Instantiate(resetButton);
        myMenuButton.transform.SetParent(canvas.transform,false);
        myResetButton.transform.SetParent(canvas.transform,false);
        myMenuButton.GetComponent<Button>().onClick.AddListener(OnMenuButtonPress);
        myResetButton.GetComponent<Button>().onClick.AddListener(OnResetButtonPress);

    }

    // Update is called once per frame
    void Update()
    {
        if (levelOngoing)
        {
            if (playerManager.GetComponent<playerSpawner>().outOfCats)
            {
                levelOngoing = false;
                levelFail();
            }
            else if(GameObject.FindWithTag("Enemy Rat")==null)
            {
                levelOngoing = false;
                levelWin();
            }
        }
        if (Input.GetKeyDown("r"))
        {
            OnResetButtonPress();
        }
        if (Input.GetKeyDown("n"))
        {
            OnNextButtonPress();
        }
        if (Input.GetKeyDown("m"))
        {
            OnMenuButtonPress();
        }


        //Bugtesting mode
        if (Input.GetKeyDown("k"))
            levelWin();
        if (Input.GetKeyDown("l"))
            levelFail();
    }

    void levelWin()
    {
        Debug.Log("Level Win");
        GameObject myPopupBG = Instantiate(PopupBG);
        GameObject myPopupResetButton = Instantiate(popupResetButton);
        GameObject myPopupNextButton = Instantiate(popupNextButton);
        GameObject mypopupWin = Instantiate(popupWin);
        myPopupBG.transform.SetParent(canvas.transform,false);
        myPopupResetButton.transform.SetParent(canvas.transform,false);
        myPopupNextButton.transform.SetParent(canvas.transform,false);
        mypopupWin.transform.SetParent(canvas.transform,false);

        myPopupResetButton.GetComponent<Button>().onClick.AddListener(OnResetButtonPress);
        myPopupNextButton.GetComponent<Button>().onClick.AddListener(OnNextButtonPress);
    }

    void levelFail()
    {
        Debug.Log("Level Lose");
        GameObject myPopupBG = Instantiate(PopupBG);
        GameObject myPopupResetButton = Instantiate(popupResetButton);
        GameObject mypopupLose = Instantiate(popupLose);
        myPopupBG.transform.SetParent(canvas.transform,false);
        myPopupResetButton.transform.SetParent(canvas.transform,false);
        mypopupLose.transform.SetParent(canvas.transform,false);
    }

    public void OnResetButtonPress()
    {
        Scene currentscene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(currentscene.name);
    }

    public void OnMenuButtonPress()
    {
        SceneLoader.Load("Main Menu");
    }

    public void OnNextButtonPress()
    {
        string currentSceneName = SceneManager.GetActiveScene().name; 
        int levelNumber = int.Parse(currentSceneName.Substring(6));
        SceneLoader.Load("Level " + (levelNumber+1).ToString());
    }

}
