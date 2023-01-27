using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
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
        // force = new Vector2(horizontal_translation, vertical_translation);
        rb.AddForce(new Vector2(horizontal_translation, vertical_translation), ForceMode2D.Impulse);

        if (Input.GetKeyDown("c"))
        {
            rb.AddForce(new Vector2(80, 20), ForceMode2D.Impulse);
        }

    }
}
