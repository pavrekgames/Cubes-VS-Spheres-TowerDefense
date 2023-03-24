using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCube : MonoBehaviour
{
    [SerializeField] protected CubeData cubeData;

    [SerializeField] protected float health;
    [SerializeField] protected float countdown;

    [SerializeField] protected GameObject dieAudioSource;
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
            GameObject newAudioSource = Instantiate(dieAudioSource, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
    }

}
