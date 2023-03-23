using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDecorator : BaseBullet
{
    protected BaseBullet bullet;

    public virtual void SetBullet()
    {
        bullet = this;
    }
 
}
