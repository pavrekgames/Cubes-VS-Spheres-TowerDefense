using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCube : MonoBehaviour
{
    [SerializeField] protected CubeData cubeData;

    [SerializeField] protected float health;
    [SerializeField] protected float countdown;
    protected virtual void Start()
    {
        health = cubeData.health;
        countdown = cubeData.countdown;
    }

    protected virtual void Update()
    {
        Death();
    } 

    protected void Death()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
    }

}
