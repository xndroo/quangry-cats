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
    public float angleSpeed = 1.0f;
    public GameObject pointer;
    private GameObject myPointer;
    private Rigidbody2D rb;
    private bool isProjectile = false;
    private float pointerDistance = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am born");
        rb = GetComponent<Rigidbody2D>();
        myPointer = Instantiate(pointer);
    }

    // Update is called once per frame
    void Update()
    {
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

        // Update pointer
        if (!isProjectile)
        {
            myPointer.transform.rotation = Quaternion.Euler(0.0f, 0.0f, launchAngle);
            myPointer.transform.position = this.transform.position+new Vector3(pointerDistance*Mathf.Cos(Mathf.Deg2Rad*launchAngle)+0.02f,
                pointerDistance*Mathf.Sin(Mathf.Deg2Rad*launchAngle)+0.44f, 0f);
        }


        if (Input.GetKeyDown("space")) // && isProjectile==false
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
