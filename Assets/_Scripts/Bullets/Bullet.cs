using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseSphere>())
        {
            collision.GetComponent<BaseSphere>().ReceiveDamage(damage);
        }

        Destroy(gameObject);

    }

}
