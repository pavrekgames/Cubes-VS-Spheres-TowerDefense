using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShooterCube : SimpleShooterCube
{

    protected override void UpdateTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, layerMask);

        if (hit.collider.GetComponent<BaseSphere>())
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, placeForBullet.position, Quaternion.identity, bulletsParent);
        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
        yield return new WaitForSeconds(0.5f);
        GameObject newBullet2 = Instantiate(bulletPrefab, placeForBullet.position, Quaternion.identity, bulletsParent);
        newBullet2.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
        StopCoroutine(Shoot());
    }

}
