using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratDestruction : MonoBehaviour
{
    private float collisionVelocity = 0.0f;
    private Rigidbody2D rb;
    public float damageThreshold = 3.0f;
    public float maxHealth = 30.0f;
    private float health;
    public SpriteRenderer spriteRenderer;
    public Sprite damaged1;
    public Sprite damaged2;
    private int damageLevel = 0;

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

    void Explode() {
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
        PointCounter.instance.AddPoints(1000);
        Destroy(this.gameObject, exp.main.duration);
    }

    void Update()
    {
        if (damageLevel <= 0 && health < maxHealth*0.66)
        {
            spriteRenderer.sprite = damaged1;
            damageLevel = 1;
        }
        if (damageLevel <= 1 && health < maxHealth*0.33)
        {
            spriteRenderer.sprite = damaged2;
            damageLevel = 2;
        }
        if (damageLevel <= 2 && health < 0.0f)
        {
            Explode();
            damageLevel = 3;
        }
    }

}
