using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class SphereFactory : MonoBehaviour
{
    public static SphereFactory instance;
    [SerializeField] private Transform spheresParent;

    public List<SphereData> spheres = new List<SphereData>();

    public Transform[] enemyPoints;

    [SerializeField] private int randomEnemyPoint = 1;

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


    private void Start()
    {
        StartCoroutine(Wave0());
    }

    void Update()
    {
       
    }

    private IEnumerator Wave0()
    {
        yield return new WaitForSeconds(20);
        CreateSphere(spheres[0], 1);
        yield return new WaitForSeconds(20);
        CreateSphere(spheres[0], 1);
        yield return new WaitForSeconds(20);
        CreateSphere(spheres[1], 1);
        yield return new WaitForSeconds(20);
        CreateSphere(spheres[0], 2);
        yield return new WaitForSeconds(20);
        CreateSphere(spheres[0], 2);
        yield return new WaitForSeconds(20);
        CreateSphere(spheres[0], 3);
        CreateSphere(spheres[3], 1);
        yield return new WaitForSeconds(20);
        CreateSphere(spheres[0], 2);
        CreateSphere(spheres[2], 1);
        CreateSphere(spheres[1], 1);
        yield return new WaitForSeconds(20);
        StartCoroutine(Wave1());
        StopCoroutine(Wave0());

    }

    private IEnumerator Wave1()
    {
        yield return new WaitForSeconds(10);
        CreateSphere(spheres[0], 15);
        CreateSphere(spheres[1], 5);
        CreateSphere(spheres[2], 2);
        yield return new WaitForSeconds(5);
        CreateSphere(spheres[0], 1);
        yield return new WaitForSeconds(4);
        CreateSphere(spheres[1], 1);
        yield return new WaitForSeconds(5);
        CreateSphere(spheres[0], 2);
        yield return new WaitForSeconds(3);
        CreateSphere(spheres[0], 2);
        yield return new WaitForSeconds(5);
        CreateSphere(spheres[0], 3);
        yield return new WaitForSeconds(2);
        CreateSphere(spheres[0], 4);
        yield return new WaitForSeconds(5);


    }

    private void CreateSphere(SphereData sphere, int spheresAmount)
    {
        for(int i=0; i < spheresAmount; i++)
        {
            randomEnemyPoint = Random.Range(0, 5);
            GameObject newSphere = Instantiate(sphere.spherePrefab, enemyPoints[randomEnemyPoint].position, enemyPoints[randomEnemyPoint].rotation, spheresParent);
        }
    }


}
