using UnityEngine;

public class Gold : MonoBehaviour
{
    private bool isPlayerNear = false; // Oyuncunun altınların yakınında olup olmadığını kontrol etmek için

    void Update()
    {
        // Oyuncu altınların yakınında ve E tuşuna basarsa
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            CollectGold();
        }
    }

    void CollectGold()
    {
        // Altınları topla (altınları devre dışı bırak)
        gameObject.SetActive(false);
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