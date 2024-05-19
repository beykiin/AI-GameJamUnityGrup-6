using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 1000.0f;

    private Transform mainCameraTransform;
    

    void Start()
    {
        
        mainCameraTransform = Camera.main.transform;
       
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }

        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
            mainCameraTransform.Rotate(Vector3.left, -mouseY * rotationSpeed * Time.deltaTime);
        }

        mainCameraTransform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        


    }
}
