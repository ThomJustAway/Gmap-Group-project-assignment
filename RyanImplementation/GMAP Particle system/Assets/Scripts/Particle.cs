using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Particle : MonoBehaviour
{
    //variables that will be edited in particle spawner
    private float _lifespan;

    private float _moveSpeed;

    private bool _moveForward;

    float time;



    private void OnEnable()
    {
        time = 0;

    }


    private void Update()
    {
        time += Time.fixedDeltaTime;
       


        if (time >= _lifespan)
        {
            this.gameObject.SetActive(false);
            
        }

        

    }

    private void FixedUpdate()
    {
        if (_moveForward)
        {
            Move();
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

    private void Move()
    {
        Vector3 forward = transform.forward;
        transform.position += (forward * _moveSpeed * Time.fixedDeltaTime);

       
    } 
  
    
    
    
    #region Getters and Setters
    public float Lifespan
    {
        get
        {
            return _lifespan;
        }

        set
        {
            _lifespan = value;
        }
    }
    
    public float MoveSpeed
    {
        get
        {
            return _moveSpeed;
        }

        set
        {
            _moveSpeed = value;
        }
    }

    public bool MoveForward
    {
        get
        {
            return _moveForward;
        }

        set
        {
            _moveForward = value;
        }
    }
    #endregion

}
