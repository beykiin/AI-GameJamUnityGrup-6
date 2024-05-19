using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollection : MonoBehaviour
{
    private bool keyCollected = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            gameObject.SetActive(false);


            DoorController doorController = FindObjectOfType<DoorController>();
            if (doorController != null)
            {
                doorController.UnlockDoor();
            }
        }
        else if (other.CompareTag("Key"))
        {

            gameObject.SetActive(false);


            keyCollected = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Door") && keyCollected)
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
    }
}
