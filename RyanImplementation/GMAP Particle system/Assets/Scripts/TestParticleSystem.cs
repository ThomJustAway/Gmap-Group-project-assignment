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
    public bool randomSpawnPosition;

    [Header("Object Pooling")]
    public ObjectPool objectPool;



    public bool start = false;

    

    void Start()
    {
        objectPool = ObjectPool.SharedInstance;


    }

    private void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(SpawnParticles());
        }

       
    }


    IEnumerator SpawnParticles()
    {
        for (int i = 0; i < numberOfParticles; i++)
        {
            if (randomSpawnPosition)
            {
                Vector3 randomPos = GetRandomPosition();

                Debug.Log(randomPos);

                // enable a new particle
                GameObject particle = objectPool.spawnFromObjectPool(randomPos, Quaternion.identity);
            }



            else
            {
                GameObject particle = objectPool.spawnFromObjectPool(transform.position, Quaternion.identity);
            }
            
            
                

            yield return new WaitForSeconds(interval);
            
            
          
        }
        
    }

    public Vector3 GetRandomPosition()
    {
        //get the random x and z value of the position
        //Vector2 randomPosXZ = Random.insideUnitCircle * transform.localScale.x;

        Vector3 randomPosition = new Vector3(Random.Range(-transform.localScale.x/2, transform.localScale.x/2), 0f, Random.Range(-transform.localScale.z/2, transform.localScale.z/2))
            + transform.position;

        

        return randomPosition;
    }

}
