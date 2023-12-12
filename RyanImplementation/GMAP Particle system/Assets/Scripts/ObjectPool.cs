using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
   
    private GameObject objectToPool;
    private int amountToPool;

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

        if (objectToSpawn.activeInHierarchy)
        {
            //turn it off before activating again
            objectToSpawn.SetActive(false);
        }

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rotation;

        objectPool.Enqueue(objectToSpawn);

        return objectToSpawn;
    }



    #region Getters and Setters
    public GameObject ObjectToPool
    {
        get
        {
            return objectToPool;
        }

        set
        {
            objectToPool = value;
        }
    }
    public int AmountToPool
    {
        get
        {
            return amountToPool;
        }

        set
        {
            amountToPool = value;
        }
    }


    #endregion

}
