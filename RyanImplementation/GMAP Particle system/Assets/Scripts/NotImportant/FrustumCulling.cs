using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrustumCulling : MonoBehaviour
{
    public GameObject obj;
    Collider objCollider;
    Camera camera;
    Plane[] planes;
    Vector3[] frustumCorners = new Vector3[4];

    void Start()
    {
        //getting frustum bounds
        camera = Camera.main;
        camera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);
        
        objCollider = obj.GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
       

        //debug the frustrum with blue :3
        for (int i = 0; i < 4; i++)
        {
            var worldSpaceCorner = camera.transform.TransformVector(frustumCorners[i]);
            Debug.DrawRay(camera.transform.position, worldSpaceCorner, Color.blue);
        }

        planes = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
        {
            Debug.Log(obj.name + " has been detected!");
        }
        else
        {
            Debug.Log("Nothing has been detected");
        }



    }
}
