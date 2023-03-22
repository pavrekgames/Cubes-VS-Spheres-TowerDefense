using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShooterCube : BaseCube
{
    [Header("Bullets Attributes")]
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform placeForBullet;
    [SerializeField] protected Transform bulletsParent;
    [SerializeField] protected float bulletSpeed;

    [Header("Enemy Target")]
    [SerializeField] protected LayerMask layerMask;

    protected override void Start()
    {
        base.Start();
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

        if (hit.collider.GetComponent<BaseSphere>())
        {
            GameObject newBullet = Instantiate(bulletPrefab, placeForBullet.position, Quaternion.identity, bulletsParent);
            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
        }

    }

}
