using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStumpDecorator : BulletDecorator
{
     public int bonusDamage = 10;
     public Color bulletDecoratorColor;

    protected override void OnEnable()
    {
        bulletRenderer = GetComponent<SpriteRenderer>();

    }
    public override void SetBullet()
    {
        bulletRenderer = GetComponent<SpriteRenderer>();
        damage = bonusDamage;
        bulletRenderer.color = bulletDecoratorColor;

    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Sphere"))
        {
            if (collision.GetComponent<BaseSphere>())
            {
                damage = bonusDamage;
                bulletRenderer.color = bulletDecoratorColor;
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
