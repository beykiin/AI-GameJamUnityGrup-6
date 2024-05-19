using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjanCollision : MonoBehaviour
{
    private KovalayanDusman kovalayanDusman;

    private void Start()
    {
        kovalayanDusman = GetComponent<KovalayanDusman>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Obstacle obstacle))
        {
            obstacle.Intreact(kovalayanDusman, -5f);
        }

        if (collision.collider.TryGetComponent(out Hedef hedef))
        {
            hedef.Intreact(kovalayanDusman, 10f);
        }
    }
}
