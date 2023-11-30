using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestParticleSystem : MonoBehaviour
{
    //settings for the particle object itself
    [Header("Particle settings")]
    public GameObject particlePrefab;
    public Color particleColor;
    Rigidbody particleRB;
    Renderer particleRenderer;
    [Space(10)]

    //settings for spawning the particles
    [Header("Spawn Settings")]
    public int numberOfParticles = 100;
    public bool randomSpeed;
    [Range(1,50)]
    public float minSpeed, maxSpeed, particleSpeed;
    public float interval;
    

    
    //for my eyes only  uwu
    float count;

    void Start()
    {
        StartCoroutine(SpawnParticles());
    }


    IEnumerator SpawnParticles()
    {
        for (int i = 0; i < numberOfParticles; i++)
        {
            // Instantiate a new particle
            GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
            
            // Get random particle direction
            Vector3 randomDirection = Random.insideUnitSphere.normalized;

            //set particle color
            //particleRenderer = particle.GetComponent<Renderer>();
            //particleRenderer.material.color = particleColor;

            //set particle velocity
            particleRB = particle.GetComponent<Rigidbody>();
            if (randomSpeed)
            {
                particleRB.velocity = randomDirection * Random.Range(minSpeed, maxSpeed);
            }
            else
            {
                
                particleRB.velocity = randomDirection * particleSpeed;
            }
            


            //set an interval between each particle spawning
            yield return new WaitForSeconds(interval);
        }
        
    }

}
