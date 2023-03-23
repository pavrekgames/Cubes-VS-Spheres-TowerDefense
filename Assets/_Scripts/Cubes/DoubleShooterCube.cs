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
            StartCoroutine(DoubleShoot());
        }
    }

    private IEnumerator DoubleShoot()
    {
        Shoot();
        yield return new WaitForSeconds(0.5f);
        Shoot();
        StopCoroutine(DoubleShoot());
    }

}
