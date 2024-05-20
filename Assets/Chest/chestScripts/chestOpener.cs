using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestOpener : MonoBehaviour
{
    public GameObject closedChest; 
    public GameObject openChest;   
    public GameObject gold;        

    private bool isOpen = false;   // Sandığın açık olup olmadığını kontrol etmek için
    private bool isPlayerNear = false; // Oyuncunun sandığın yakınında olup olmadığını kontrol etmek için

    void Update()
    {
        // Oyuncu sandığın yakınında ve E tuşuna basarsa
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
            {
                // Sandık açıkken tekrar E tuşuna basılırsa, altınları kaybet
                gold.SetActive(false);
            }
            else
            {
                // Sandık kapalıysa aç
                OpenChest();
            }
        }
    }

    void OpenChest()
    {
        isOpen = true;
        closedChest.SetActive(false); 
        openChest.SetActive(true);    
        gold.SetActive(true);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
