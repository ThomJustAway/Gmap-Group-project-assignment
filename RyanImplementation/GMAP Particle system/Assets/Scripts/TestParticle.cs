using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestParticle : MonoBehaviour
{
    [SerializeField]
    [Range(1,100)]
    public float lifespan;
    [Range(1, 100)]
    public float collisionBuffer;

    float time;

    private void OnEnable()
    {
        time = 0;
    }


    private void Update()
    {
        time += Time.fixedDeltaTime;

        
        if (time >= lifespan)
        {
            this.gameObject.SetActive(false);
            
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(time > collisionBuffer)
    //    {
    //        this.gameObject.SetActive(false);
    //    }
    //    
    //}
}
