using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleSystem : MonoBehaviour
{
    //settings for the particle object itself
    [Header("Particle settings")]
    public GameObject prefab;
    [Range(1, 100000)]
    public float lifespan;




    //settings for spawning the particles
    [Header("Spawn Settings")]
    public int numberOfParticles = 100;
    public float interval;
    public bool randomSpawnPosition;




    [Header("Object Pooling")]
    public int amountToPool;
    public ObjectPool objectPool;
    public bool objectPoolCheck;
    




    [Header("Move to target")]
    public bool moveForward;
    [Range(1, 500)]
    public float moveSpeed;




    public bool start = false;

    private void Awake()
    {
        objectPool = ObjectPool.SharedInstance;
        SetObjectPoolVariables();
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
        if (objectPoolCheck)
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                if (randomSpawnPosition)
                {
                    Vector3 randomPos = GetRandomPosition();

                    Debug.Log(randomPos);

                    // enable a new particle
                    GameObject particle = objectPool.spawnFromObjectPool(randomPos, transform.rotation);
                    SetParticleVariables(particle);
                }



                else
                {
                    GameObject particle = objectPool.spawnFromObjectPool(transform.position, transform.rotation);
                    SetParticleVariables(particle);
                }




                yield return new WaitForSeconds(interval);



            }
        }
        else
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                if (randomSpawnPosition)
                {
                    Vector3 randomPos = GetRandomPosition();

                    Debug.Log(randomPos);

                    // enable a new particle
                    GameObject particle = SpawnObjects(randomPos);
                    SetParticleVariables(particle);
                }



                else
                {
                    GameObject particle = SpawnObjects(transform.position);
                    SetParticleVariables(particle);
                }




                yield return new WaitForSeconds(interval);



            }
        }
        
        
    }

    public Vector3 GetRandomPosition()
    {
        //get the random x and z value of the position
        //Vector2 randomPosXZ = Random.insideUnitCircle * transform.localScale.x;

        Vector3 randomPosition = new Vector3(Random.Range(-transform.localScale.x/2, transform.localScale.x/2), 0f, Random.Range(-transform.localScale.z/2, transform.localScale.z/2)) + transform.position;

        

        return randomPosition;
    }

    public GameObject SpawnObjects(Vector3 pos)
    {
        GameObject particle = Instantiate(prefab);
        particle.transform.position = pos;
        particle.transform.rotation = transform.rotation;
        return particle;
    }


    #region Set Variables
    public void SetParticleVariables(GameObject particle)
    {
        Particle p = particle.GetComponent<Particle>();
        p.Lifespan = lifespan;
        p.MoveSpeed = moveSpeed;
        p.MoveForward = moveForward;
    }


    public void SetObjectPoolVariables()
    {
        objectPool.AmountToPool = amountToPool;
        objectPool.ObjectToPool = prefab;
    }

    #endregion

}
