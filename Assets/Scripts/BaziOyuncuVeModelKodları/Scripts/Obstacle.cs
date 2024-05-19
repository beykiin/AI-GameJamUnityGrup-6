using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IIntreactable
{
    public void Intreact(KovalayanDusman ajan, float amount)
    {
        ajan.HedefeVardi(amount);
    }
}
