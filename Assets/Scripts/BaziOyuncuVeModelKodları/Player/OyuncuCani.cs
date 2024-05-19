using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyuncuCani : MonoBehaviour
{
    [SerializeField] private Slider canBariUI;
    [SerializeField] private float baslangicCani;
    private float simdikiCani;

    private void Start()
    {
        simdikiCani = baslangicCani;
    }

    private void Update()
    {
        if(simdikiCani <= 0f)
        {
            KarakterOldur();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            CaniAzalt(15f);
        }
    }

    public void CaniAzalt(float miktar)
    {
        simdikiCani -= miktar;
        canBariUI.value = simdikiCani / baslangicCani;
    }

    private void KarakterOldur()
    {
        Debug.Log("Oyun bitti");
        gameObject.SetActive(false);
    }
}
