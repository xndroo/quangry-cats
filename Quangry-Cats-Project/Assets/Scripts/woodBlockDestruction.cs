using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodBlockDestruction : MonoBehaviour
{
    private float collisionVelocity = 0.0f;
    private Rigidbody2D rb;
    public float damageThreshold = 5.0f;
    [SerializeField]
    private float health;

    public float maxHealth = 10.0f;
    public SpriteRenderer spriteRenderer;
    public Sprite damaged;
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

    void Splinter()
    {
    	var exp = GetComponent<ParticleSystem>();
      exp.Play();
      PointCounter.instance.AddPoints(10);
    	Destroy(this.gameObject, exp.main.duration);
    }

    void Update()
    {
    	if((health < maxHealth*0.5) && (damageLevelblock < 1))
        {
    	    spriteRenderer.sprite = damaged;
            damageLevelblock = 1;
        }
    	if((health < 0.0f)  && (damageLevelblock < 2))
        {
            Splinter();
            damageLevelblock = 2;
        }
    }
}
