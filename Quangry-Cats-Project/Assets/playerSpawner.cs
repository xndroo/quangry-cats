using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawner : MonoBehaviour
{
    public GameObject cat1; // Presets for cats
    public bool outOfCats = false;
    private GameObject mycat = null; // current cat
    private int mycattype;

    public List<int> cats = new List<int>() { 1, 1, 1, 1, 1 };
    // Start is called before the first frame update
    void Start()
    {
        summonCat();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c")) // && isProjectile==false
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
            CameraControl.trackingTarget = mycat.transform;
            if (cats.Count==0)
            {
                outOfCats = true;
            }
        }
    }
}
