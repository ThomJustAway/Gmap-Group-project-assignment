using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    public GameObject particleSystem;
    public int count;

    private void Start()
    {
        for(int i = 0; i < count; i++)
        {
            Instantiate(particleSystem);
        }
    }
}
