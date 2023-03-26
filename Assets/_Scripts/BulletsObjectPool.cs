using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsObjectPool : MonoBehaviour
{
    public static BulletsObjectPool instance;

    public List<GameObject> simpleBullets = new List<GameObject>();
    public List<GameObject> freezeBullets = new List<GameObject>();
    public List<GameObject> multiLinesbullets = new List<GameObject>();

    public BulletPool[] bulletPools;
    public Transform bulletsParent;

    [Serializable]
    public struct BulletPool
    {
        public GameObject bulletToPool;
        public int bulletAmount;

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CreateBullets(simpleBullets, bulletPools[0]);
        CreateBullets(freezeBullets, bulletPools[1]);
        CreateBullets(multiLinesbullets, bulletPools[2]);
    }

    private void CreateBullets(List<GameObject> bulletsList, BulletPool bulletPool)
    {
        GameObject newBullet;

        for (int i = 0; i < bulletPool.bulletAmount; i++)
        {
            newBullet = Instantiate(bulletPool.bulletToPool, bulletsParent);
            newBullet.SetActive(false);
            bulletsList.Add(newBullet);
        }
    }

    public GameObject GetPooledObject(List<GameObject> bulletsList, BulletPool bulletPool)
    {
        for (int i = 0; i < bulletPool.bulletAmount; i++)
        {
            if (!bulletsList[i].activeInHierarchy)
            {
                return bulletsList[i];
            }
        }
        return null;
    }

}
