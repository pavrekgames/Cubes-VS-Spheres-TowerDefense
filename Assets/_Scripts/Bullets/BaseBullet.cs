using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{

    [Header("Bullets Attributes")]
    [SerializeField] protected int damage;
    [SerializeField] protected SpriteRenderer bulletRenderer;
    [SerializeField] protected Color defaultColor;

    protected virtual void OnEnable()
    {

        bulletRenderer = GetComponent<SpriteRenderer>();

        if (gameObject.GetComponent<BulletDecorator>())
        {
            bulletRenderer.color = defaultColor;
            Destroy(gameObject.GetComponent<BulletDecorator>());
        }

    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sphere"))
        {
            if (collision.GetComponent<BaseSphere>())
            {
                collision.GetComponent<BaseSphere>().ReceiveDamage(damage);
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

}
