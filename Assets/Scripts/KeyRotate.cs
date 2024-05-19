using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotate : MonoBehaviour
{
    public float rotationSpeed = 300.0f; // Anahtarın dönme hızı

    void Update()
    {
        // Anahtarın etrafında dönme işlemi
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
