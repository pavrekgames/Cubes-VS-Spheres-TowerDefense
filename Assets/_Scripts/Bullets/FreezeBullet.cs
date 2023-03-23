using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBullet : BaseBullet
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Sphere"))
        {
            if (collision.GetComponent<BaseSphere>())
            {
                collision.GetComponent<BaseSphere>().FreezeState();
                collision.GetComponent<BaseSphere>().ReceiveDamage(damage);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
