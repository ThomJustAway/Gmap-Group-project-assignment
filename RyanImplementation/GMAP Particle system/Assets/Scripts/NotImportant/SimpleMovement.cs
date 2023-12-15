using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed,turnSpeed = 4f;
    Rigidbody rb;

    public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput.Normalize();
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);



        Vector3 velocity = cameraTransform.TransformDirection( playerInput.x, 0f, playerInput.y) * moveSpeed;
        Vector3 displacement = velocity * Time.deltaTime;
        transform.localPosition += displacement;



        cameraTransform.position = transform.position;
        cameraTransform.rotation = transform.rotation;



        float y = Input.GetAxis("Mouse X") * turnSpeed;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
