using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float launchAngle = 45.0f;
    public float launchSpeed = 5.0f;
    public float gravity = -500.0f;
    public float uncertainty = 1.0f;
    public float uncertaintyRatio = 0.5f;
    public float uncertaintyRatioMin = -1.0f;
    public float uncertaintyRatioMax = 1.0f;
    public float uncertaintyPositionScale = 5.0f;
    public float uncertaintyAngleScale = 30.0f;
    public float uncertaintyDelay = 1.0f;
    public float angleSpeed = 1.0f;
    public float uncertaintyAngleLength = 4.0f;
    public float uncertaintyCircleWidth = 2.0f;
    public float uncertaintyRatioScrollSpeed = 1.0f;
    public GameObject pointer;
    public GameObject uncertaintyCircle;
    public GameObject uncertaintyTriangle;
    private GameObject myPointer;
    private GameObject myuncertaintyCircle;
    private GameObject myuncertaintyTriangle;
    private Rigidbody2D rb;
    public bool isProjectile = false;
    private float pointerDistance = 5.0f;
    private float sigmapos;
    private float sigmaangle;
    private float deltapos;
    private float deltaangle;
    private float delayTimer = 0.0f;
    private bool beginDelayTimer = false;

    float gaussianDistribution(float stdDev)
    {
        System.Random rand = new System.Random(); //reuse this if you are generating many
        float u1 = 1.0f - (float) rand.NextDouble(); //uniform(0,1] random doubles
        float u2 = 1.0f - (float) rand.NextDouble();
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2); //random normal(0,1)
        float randNormal =
                     Mathf.Sqrt(stdDev) * randStdNormal; //random normal(mean,stdDev^2)
        return (float) randNormal;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myPointer = Instantiate(pointer);
        if (uncertainty > 0.0f)
        {
            myuncertaintyCircle = Instantiate(uncertaintyCircle);
            myuncertaintyTriangle = Instantiate(uncertaintyTriangle);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (beginDelayTimer)
        {
            delayTimer += Time.deltaTime;
        }
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float vertical_translation = Input.GetAxis("Vertical") * speed;
        float horizontal_translation = Input.GetAxis("Horizontal") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        vertical_translation *= Time.deltaTime;
        horizontal_translation *= Time.deltaTime;

        // Move translation
        if (!isProjectile)
        {
            rb.AddForce(new Vector2(0, vertical_translation), ForceMode2D.Impulse);
        }

        // Update and control uncertainties
        uncertaintyRatio += Input.mouseScrollDelta.y * uncertaintyRatioScrollSpeed;
        if (uncertaintyRatio > uncertaintyRatioMax)
            uncertaintyRatio = uncertaintyRatioMax;
        if (uncertaintyRatio < uncertaintyRatioMin)
            uncertaintyRatio = uncertaintyRatioMin;
        sigmapos = Mathf.Pow(10,-uncertaintyRatio);
        sigmaangle = Mathf.Pow(10,uncertaintyRatio);


        // Update pointer
        if (!isProjectile)
        {
            myPointer.transform.rotation = Quaternion.Euler(0.0f, 0.0f, launchAngle);
            myPointer.transform.position = this.transform.position+new Vector3(pointerDistance*Mathf.Cos(Mathf.Deg2Rad*launchAngle)+0.02f,
                pointerDistance*Mathf.Sin(Mathf.Deg2Rad*launchAngle)+0.44f, 0f);
        }
        //Update quantum indicators
        if (delayTimer==0f && (uncertainty > 0.0f))
        {
            myuncertaintyCircle.transform.position = this.transform.position;
            myuncertaintyTriangle.transform.rotation = Quaternion.Euler(0.0f, 0.0f, launchAngle+90f);
            myuncertaintyTriangle.transform.position = this.transform.position+new Vector3(0.5f*uncertaintyAngleLength*
                Mathf.Cos(Mathf.Deg2Rad*
                launchAngle)+0.02f,0.5f*uncertaintyAngleLength*Mathf.Sin(Mathf.Deg2Rad*launchAngle)+0.44f, 0f);

            myuncertaintyCircle.transform.localScale = new Vector2(uncertaintyCircleWidth,sigmapos*uncertaintyPositionScale);
            myuncertaintyTriangle.transform.localScale = new Vector2(sigmaangle*uncertaintyAngleScale,uncertaintyAngleLength);
        }


        if (Input.GetKeyDown("space") && beginDelayTimer==false) // Make the position and momentum uncertain
        {
            if (uncertainty > 0.0f)
            {

                deltapos = gaussianDistribution(sigmapos) * uncertaintyPositionScale;
                deltaangle = gaussianDistribution(sigmaangle) * uncertaintyAngleScale;
                rb.position = new Vector2(rb.position.x, rb.position.y + deltapos);
                launchAngle = launchAngle + deltaangle;
            }
            beginDelayTimer = true;
            Destroy(myuncertaintyCircle);
            Destroy(myuncertaintyTriangle);
        }
        if (delayTimer > uncertaintyDelay  && isProjectile==false) //Fire the cat
        {
            rb.AddForce(new Vector2(launchSpeed*Mathf.Cos(Mathf.Deg2Rad*launchAngle), launchSpeed*Mathf.Sin(Mathf.Deg2Rad*launchAngle))
                , ForceMode2D.Impulse);
            isProjectile = true;
            Destroy(myPointer);
        }

        // Change launch angle
        if (Input.GetKey("a"))
        {
            launchAngle += angleSpeed*Time.deltaTime;
        }
        else if (Input.GetKey("d"))
        {
            launchAngle -= angleSpeed*Time.deltaTime;
        }

        //Add gravity if in air
        if (isProjectile)
        {
            rb.AddForce(new Vector2(0f, gravity*Time.deltaTime), ForceMode2D.Force);
            rb.drag = 0.0f;
        }

    }


}
