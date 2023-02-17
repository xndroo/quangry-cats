using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleEmitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var particles = GetComponent<ParticleSystem>();
        particles.Play();
        Destroy(this.gameObject, particles.main.duration); 
    }


}
