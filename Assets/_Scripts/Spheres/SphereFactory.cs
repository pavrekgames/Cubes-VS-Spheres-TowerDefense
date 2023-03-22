using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class SphereFactory : MonoBehaviour
{
    public static SphereFactory instance;

    public Transform[] enemyPoints;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    void Update()
    {
       
    }
}
