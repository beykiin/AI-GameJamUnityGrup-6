using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public string SampleScene;
    private bool isLocked = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLocked)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (other.CompareTag("Player") && isLocked)
        {
            Debug.Log("Kapý kilitli. Anahtarý bulmalýsýn!");
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }
}
