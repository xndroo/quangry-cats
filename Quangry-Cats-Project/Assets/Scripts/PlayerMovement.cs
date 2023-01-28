using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float launchAngle = 45.0f;
    public float launchSpeed = 5.0f;
    public float gravity = -500.0f;
    private Rigidbody2D rb;
    private bool isProjectile = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am born");
        rb = GetComponent<Rigidbody2D>();
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

        if (Input.GetKeyDown("space")) // && isProjectile==false
        {
            rb.AddForce(new Vector2(launchSpeed*Mathf.Cos(Mathf.Deg2Rad*launchAngle), launchSpeed*Mathf.Sin(Mathf.Deg2Rad*launchAngle))
                , ForceMode2D.Impulse);
            isProjectile = true;
        }

        if (isProjectile)
        {
            rb.AddForce(new Vector2(0f, gravity*Time.deltaTime), ForceMode2D.Force);
            rb.drag = 0.0f;
        }

    }
}
