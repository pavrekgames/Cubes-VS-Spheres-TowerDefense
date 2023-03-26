using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireStumpCube : BaseCube
{
    [Header("FireStump Attributes")]
    [SerializeField] private int bonusDamage = 10;
    [SerializeField] private Color bulletDecoratorColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            FireStumpDecorator decoratedBullet = collision.AddComponent<FireStumpDecorator>();
            decoratedBullet.bonusDamage = bonusDamage;
            decoratedBullet.bulletDecoratorColor = bulletDecoratorColor;
            decoratedBullet.SetBullet();
        }
    }

}
