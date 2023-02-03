using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metalBlockDestruction : MonoBehaviour
{
    private float collisionVelocity = 0.0f;
    private Rigidbody2D rb;
    public float damageThreshold = 5.0f;
    private float health;
    public float maxHealth = 25.0f;
    public SpriteRenderer spriteRenderer;
    public Sprite damaged1;
    public Sprite damaged2;
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

    void Break()
    {
    	var exp = GetComponent<ParticleSystem>();
      exp.Play();
      PointCounter.instance.AddPoints(15);
    	Destroy(this.gameObject, exp.main.duration);
    }

    void Update()
    {
    	if((health < maxHealth*0.66) && (damageLevelblock < 1))
        {
    	    spriteRenderer.sprite = damaged1;
            damageLevelblock = 1;
        }
    	if((health < maxHealth*0.33) && (damageLevelblock < 2))
        {
    	    spriteRenderer.sprite = damaged2;
            damageLevelblock = 2;
        }
    	if((health < 0.0f)  && (damageLevelblock < 3))
        {
            Break();
            damageLevelblock = 3;
        }
    }
}
