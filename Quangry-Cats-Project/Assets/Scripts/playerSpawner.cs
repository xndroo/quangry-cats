using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawner : MonoBehaviour
{
    public GameObject cat1; // Presets for cats
    public GameObject cat2;
    public bool outOfCats = false;
    public float despawnTime = 2.0f;
    private GameObject mycat = null; // current cat
    private int mycattype;
    private float despawnTimer = 0.0f;
    // private RigidBody2D catrb;

    public List<int> cats = new List<int>() {2, 2, 1};
    // Start is called before the first frame update
    void Start()
    {
        summonCat();
    }

    // Update is called once per frame
    void Update()
    {
        if(false)
        {
            despawnTimer+= Time.deltaTime;
        }

        if (Input.GetKeyDown("c")) // && isProjectile==false
        {
            summonCat();
        }
        if ((despawnTimer > despawnTime) || mycat.transform.position.y < -10.0f)
        {
            summonCat();
        }
    }

    void summonCat()
    {
        if (!outOfCats)
        {
            if (!(mycat == null))
            {
                Destroy(mycat);
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
            // catrb = mycat.GetComponent<RigidBody2D>();
            if (cats.Count==0)
            {
                outOfCats = true;
            }
        }
    }
}
