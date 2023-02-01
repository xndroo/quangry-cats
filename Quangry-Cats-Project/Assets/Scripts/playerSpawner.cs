using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public List<int> cats = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        summonCat();

    }

    // Update is called once per frame
    void Update()
    {
        if(mycat.GetComponent<PlayerMovement>().isProjectile && catrb.velocity.y < 0.5f && catrb.velocity.x < 0.5f)
        {
            despawnTimer+= Time.deltaTime;
        }
        else 
        {
            despawnTimer = 0f;
        }

        if (Input.GetKeyDown("c") && mycat.GetComponent<PlayerMovement>().isProjectile 
            || (despawnTimer > despawnTime) || mycat.transform.position.y < -10.0f)
        {
            summonCat();
        }
    }

    void summonCat()
    {
        despawnTimer = 0.0f;
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
            catrb = mycat.GetComponent<Rigidbody2D>();
            if (cats.Count==0)
            {
                outOfCats = true;
            }
        }
    }
}
