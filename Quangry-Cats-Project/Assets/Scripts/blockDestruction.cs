using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockDestruction : MonoBehaviour
{
    private float collisionVelocity = 0.0f;
    private Rigidbody2D rb;
    public float damageThreshold = 5.0f;
    // private float health = 3.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        collisionVelocity = col.relativeVelocity.magnitude;
        
        if (collisionVelocity > damageThreshold)
        {
            Debug.Log(collisionVelocity);
        }
    }

}
