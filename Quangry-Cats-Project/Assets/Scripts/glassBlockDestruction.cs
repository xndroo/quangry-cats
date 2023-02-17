using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassBlockDestruction : MonoBehaviour
{
    private float collisionVelocity = 0.0f;
    private Rigidbody2D rb;
    public float damageThreshold = 5.0f;
    private float health;
    public float maxHealth = 5.0f;
    private int damageLevelblock = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	    health = maxHealth;
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        collisionVelocity = col.relativeVelocity.magnitude;
        
        if (collisionVelocity > damageThreshold)
        {
            health = health - collisionVelocity;
        }
    }

    void Shard()
    {
    	var exp = GetComponent<ParticleSystem>();
    	exp.Play();
	    PointCounter.instance.AddPoints(5);
    	Destroy(this.gameObject, exp.main.duration);
    }

    void Update()
    {
    	if((health < 0.0f)  && (damageLevelblock < 1))
        {
            Shard();
            damageLevelblock = 1;
        }
    }
}
