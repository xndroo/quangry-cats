using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericDestruction : MonoBehaviour
{
    private float collisionVelocity = 0.0f;
    private Rigidbody2D rb;
    public float damageThreshold = 3.0f;
    public float maxHealth = 45.0f;
    public int numberDamageLevels = 3; //including death as a damage level
    public SpriteRenderer spriteRenderer;
    public List<Sprite> Sprites = new List<Sprite>();
    public int deathPoints;
    public GameObject deathEffects;
    private int damageLevel = 0;

    public float health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        collisionVelocity = col.relativeVelocity.magnitude;
        
        if (collisionVelocity > damageThreshold)
        {
            health = health - collisionVelocity;
        }
    }

    void Update()
    {
        if (health < 0.0f)
        {
            GameObject mydeathEffect = Instantiate(deathEffects, transform.position, transform.rotation);
            mydeathEffect.GetComponent<Rigidbody2D>().velocity = rb.velocity;
            PointCounter.instance.AddPoints(deathPoints);
            Destroy(this.gameObject);
        }

        float damageRatio = 1.0f - (health/maxHealth);
        int currentDamageLevel = (int) (damageRatio * numberDamageLevels);

        if (currentDamageLevel > damageLevel && currentDamageLevel - 1 < Sprites.Count )
        {
            damageLevel = currentDamageLevel;
            spriteRenderer.sprite = Sprites[damageLevel - 1];
        }

    }

}
