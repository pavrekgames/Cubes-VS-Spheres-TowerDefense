using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLinesShooterCube : SimpleShooterCube
{
    [Header("Additonal Barrels")]
    [SerializeField] private GameObject mulitLinesBulletPrefab;
    [SerializeField] private Transform placeforBullet2;
    [SerializeField] private Transform placeforBullet3;

    [Header("Lines Targets")]
    [SerializeField] private Transform upLineTarget;
    [SerializeField] private Transform downLineTarget;

    protected override void Update()
    {
        base.Update();
    }

    protected override void UpdateTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, layerMask);
        RaycastHit2D hitUp = Physics2D.Raycast(upLineTarget.position, Vector2.right, Mathf.Infinity, layerMask);
        RaycastHit2D hitDown = Physics2D.Raycast(downLineTarget.position, Vector2.right, Mathf.Infinity, layerMask);

        if (hit.collider != null || hitUp.collider != null || hitDown.collider != null)
        {
            if (hit.collider.GetComponent<BaseSphere>() || hitUp.collider.GetComponent<BaseSphere>() || hitDown.collider.GetComponent<BaseSphere>())
            {
                Shoot();
                MultiLinesShoot(placeforBullet2, upLineTarget);
                MultiLinesShoot(placeforBullet3, downLineTarget);
            }
        }
    }
    private void MultiLinesShoot(Transform placeforBullet, Transform lineTarget)
    {
        GameObject newBullet = bulletsObjectPool.GetPooledObject(bulletsObjectPool.multiLinesbullets, bulletsObjectPool.bulletPools[2]);
        SetMultiLinesBullet(newBullet, placeforBullet, lineTarget);
        audioSource.PlayOneShot(shootSound);
    }

    private void SetMultiLinesBullet(GameObject bullet,Transform placeForBullet, Transform lineTarget)
    {
        bullet.transform.position = placeForBullet.transform.position;
        bullet.transform.rotation = placeForBullet.transform.rotation;
        bullet.SetActive(true);
        bullet.GetComponent<MultiLinesBullet>().lineTarget = lineTarget;
    }

}

