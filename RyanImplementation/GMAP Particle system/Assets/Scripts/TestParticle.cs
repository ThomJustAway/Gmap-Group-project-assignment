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
    
    private void Update()
    {
        time += Time.fixedDeltaTime;
        Debug.Log(time);

        
        if (time >= lifespan)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(time > collisionBuffer)
        {
            Destroy(this.gameObject);
        }
        
    }
}
