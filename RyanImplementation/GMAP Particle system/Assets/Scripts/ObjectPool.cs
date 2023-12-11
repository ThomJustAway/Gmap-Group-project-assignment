using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
   
    public GameObject objectToPool;
    public int amountToPool;

    public Queue<GameObject> objectPool = new Queue<GameObject>();

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.transform.parent = this.transform;
            obj.SetActive(false);
            objectPool.Enqueue(obj);

           
        }


    }

    public GameObject spawnFromObjectPool(Vector3 pos, Quaternion rotation)
    {
        GameObject objectToSpawn = objectPool.Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rotation;

        objectPool.Enqueue(objectToSpawn);

        return objectToSpawn;
    }



}
