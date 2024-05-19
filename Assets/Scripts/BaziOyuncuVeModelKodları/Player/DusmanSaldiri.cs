using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanSaldiri : MonoBehaviour, IDusman
{
    public void Saldiri(OyuncuCani oyuncuCani)
    {
        float miktar = Random.Range(10f,15f);
        oyuncuCani.CaniAzalt(miktar);
    }
}
