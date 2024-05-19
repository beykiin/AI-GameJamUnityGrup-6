using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedef : MonoBehaviour, IIntreactable
{
    public void Intreact(KovalayanDusman ajan, float amount)
    {
        ajan.HedefeVardi(amount);
    }
}
