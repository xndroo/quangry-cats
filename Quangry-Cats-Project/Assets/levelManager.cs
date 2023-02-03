using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject resetButton; 
    public GameObject canvas;
    public bool levelOngoing = true;
    private GameObject playerManager;



    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager");
        Debug.Log(playerManager);

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
    }

    void levelWin()
    {
        Debug.Log("Level Win");
    }

    void levelFail()
    {
        Debug.Log("Level Lose");
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

}
