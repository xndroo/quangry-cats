using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSpawner : MonoBehaviour
{
    public GameObject cat1; // Presets for cats
    public GameObject cat2;
    public bool outOfCats = false;
    public float despawnTime = 1.0f;
    private GameObject mycat = null; // current cat
    private int mycattype;
    private float despawnTimer = 0.0f;
    private Rigidbody2D catrb;

    public List<Sprite> Sprites = new List<Sprite>(); //List of Sprites added from the Editor to be created as GameObjects at runtime
    public GameObject ParentPanel; //Parent Panel you want the new Images to be children of


    public List<int> cats = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cats.Count; i++)
        {
            Sprite currentSprite = Sprites[cats[i]-1];
            GameObject NewObj = new GameObject("catsprite"+i.ToString()); //Create the GameObject
            Image NewImage = NewObj.AddComponent<Image>(); //Add the Image Component script
            NewImage.sprite = currentSprite; //Set the Sprite of the Image Component on the new GameObject
            NewObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform); //Assign the newly created Image GameObject 
            NewObj.SetActive(true); //Activate the GameObject
            NewObj.GetComponent<RectTransform>().anchorMin = new Vector2(1f, 1f);
            NewObj.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);
            NewObj.GetComponent<RectTransform>().localScale = new Vector3( 0.5f*(1f-(0.5f*(cats[i]-1f))), 0.5f*(1f-(0.5f*(cats[i]-1f))), 1f);
            NewObj.GetComponent<RectTransform>().anchoredPosition = new Vector3( -60f - 30f*i, -60f, 0f );
        }

        summonCat();
    }

    // Update is called once per frame
    void Update()
    {
        if(mycat.GetComponent<PlayerMovement>().isProjectile && catrb.velocity.y < 0.5f && catrb.velocity.x < 1.0f)
        {
            despawnTimer+= Time.deltaTime;
        }
        else 
        {
            despawnTimer = 0f;
        }

        if (Input.GetKeyDown("c") && mycat.GetComponent<PlayerMovement>().isProjectile 
            || (despawnTimer > despawnTime) || mycat.transform.position.y < -25.0f)
        {
            summonCat();
        }

        if (!mycat.GetComponent<PlayerMovement>().isProjectile && Input.GetKeyDown("4"))
        {
            mycat.GetComponent<PlayerMovement>().launchSpeed = 200;
        }

    }

    void summonCat()
    {
        despawnTimer = 0.0f;
        if (cats.Count > 0)
        {
            if (!(mycat == null))
            {
                Destroy(mycat);
                Destroy(GameObject.Find("catsprite"+(cats.Count).ToString()));
            }
            mycattype = cats[0];
            cats.RemoveAt(0);
            if (mycattype == 1)
            {
                mycat = Instantiate(cat1);
            }
            else if (mycattype == 2)
            {
                mycat = Instantiate(cat2);
            }
            CameraControl.trackingTarget = mycat.transform;
            catrb = mycat.GetComponent<Rigidbody2D>();
        }
        else 
        {
            outOfCats = true;
        }
    }
}
