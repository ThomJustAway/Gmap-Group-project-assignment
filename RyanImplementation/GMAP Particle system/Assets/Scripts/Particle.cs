using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Particle : MonoBehaviour
{
    
    private float _lifespan;

    private float _moveSpeed;

    private bool _moveForward;

    float time;

    Rigidbody rb;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        time = 0;

    }


    private void Update()
    {
        time += Time.deltaTime;
       


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
        rb.velocity += forward * _moveSpeed * Time.fixedDeltaTime;

       
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
