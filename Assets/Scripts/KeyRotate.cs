using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotate : MonoBehaviour
{
    public float rotationSpeed = 300.0f;

    void Update()
    {

        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
