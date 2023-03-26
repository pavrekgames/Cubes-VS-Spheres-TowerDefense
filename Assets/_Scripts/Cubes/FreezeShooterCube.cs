using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeShooterCube : SimpleShooterCube
{
    protected override void Update()
    {
        base.Update();
    }

    protected override void Shoot()
    {
        GameObject newBullet = bulletsObjectPool.GetPooledObject(bulletsObjectPool.freezeBullets, bulletsObjectPool.bulletPools[1]);
        SetBullet(newBullet);
        audioSource.PlayOneShot(shootSound);
    }

}
