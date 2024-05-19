using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Eğer etkileşen nesne bir oyuncu ise
        {
            // Anahtarın kaybolması
            gameObject.SetActive(false);
        }
    }
}
