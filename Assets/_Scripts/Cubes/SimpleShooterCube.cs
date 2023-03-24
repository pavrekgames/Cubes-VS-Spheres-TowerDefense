using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShooterCube : BaseCube
{
    [Header("Bullet Object Pooling")]
    [SerializeField] protected BulletsObjectPool bulletsObjectPool;

    [Header("Bullets Attributes")]
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform placeForBullet;
    [SerializeField] protected Transform bulletsParent;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip shootSound;

    [Header("Enemy Target")]
    [SerializeField] protected LayerMask layerMask;

    protected override void Start()
    {
        base.Start();
        bulletsObjectPool = BulletsObjectPool.instance;
        bulletsParent = GameObject.Find("BULLETS").transform;
        InvokeRepeating("UpdateTarget", 0, countdown);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected virtual void UpdateTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, layerMask);

        if(hit.collider != null)
        {
            if (hit.collider.GetComponent<BaseSphere>())
            {
                Shoot();
            }
        }
    }

    protected virtual void Shoot()
    {
        GameObject newBullet = bulletsObjectPool.GetPooledObject(bulletsObjectPool.simpleBullets, bulletsObjectPool.bulletPools[0]);
        SetBullet(newBullet);
        audioSource.PlayOneShot(shootSound);
        
    }

    protected void SetBullet(GameObject bullet)
    {
        bullet.transform.position = placeForBullet.transform.position;
        bullet.transform.rotation = placeForBullet.transform.rotation;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
    }

}
