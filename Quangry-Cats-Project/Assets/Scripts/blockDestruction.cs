using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockDestruction : MonoBehaviour
{
    private float collisionVelocity = 0.0f;
    private Rigidbody2D rb;
    public float damageThreshold = 5.0f;
<<<<<<< HEAD
<<<<<<< HEAD
    private float health;
    public float maxHealth = 10.0f;
    public SpriteRenderer spriteRenderer;
    public Sprite damaged;
=======
    // private float health = 3.0f;
>>>>>>> f7d776f755d049b8261157f6353c0f3db738997d
=======
    private float health = 3.0f;
>>>>>>> b9a09d2e26b9e673c31c12230524d180c3713b70

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

    void Splinter()
    {
	var exp = GetComponent<ParticleSystem>();
	exp.Play();
	Destroy(this.gameObject, exp.duration);
    }

    void Update()
    {
	if(health < maxHealth*0.5)
	    spriteRenderer.sprite = damaged;
	if(health < 0.0f)
	    Splinter();
    }
}
