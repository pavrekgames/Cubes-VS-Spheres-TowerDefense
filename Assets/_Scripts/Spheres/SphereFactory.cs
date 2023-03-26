using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class SphereFactory : MonoBehaviour
{
    public static SphereFactory instance;
    [SerializeField] private Transform spheresParent;

    public List<GameObject> spheres = new List<GameObject>();
    public Dictionary<string, GameObject> pairSpheres = new Dictionary<string, GameObject>();

    public Transform[] enemyPoints;

    [SerializeField] private int randomEnemyPoint = 1;

    [Header("Spheres Names")]
    [SerializeField] private string simpleSphere = "SimpleSphere";
    [SerializeField] private string armoredOrangeSphere = "ArmoredOrangeSphere";
    [SerializeField] private string armoredGreySphere = "ArmoredGreySphere";
    [SerializeField] private string newspaperSphere = "NewspaperSphere";
    [SerializeField] private string polemanSphere = "PolemanSphere";
    [SerializeField] private string boxExplodeSphere = "BoxExplodeSphere";
    [SerializeField] private string armoredSportmanSphere = "ArmoredSportmanSphere";

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
        AddSpheresToDictionary();
        StartCoroutine(Wave0());
    }

    void Update()
    {
       
    }

    private IEnumerator Wave0()
    {
        yield return new WaitForSeconds(20);
        CreateSphere(pairSpheres[simpleSphere], 1);
        yield return new WaitForSeconds(20);
        CreateSphere(pairSpheres[simpleSphere], 1);
        yield return new WaitForSeconds(20);
        CreateSphere(pairSpheres[armoredOrangeSphere], 1);
        yield return new WaitForSeconds(20);
        CreateSphere(pairSpheres[simpleSphere], 2);
        yield return new WaitForSeconds(20);
        CreateSphere(pairSpheres[simpleSphere], 2);
        yield return new WaitForSeconds(20);
        CreateSphere(pairSpheres[simpleSphere], 3);
        CreateSphere(pairSpheres[newspaperSphere], 1);
        yield return new WaitForSeconds(20);
        CreateSphere(pairSpheres[simpleSphere], 2);
        CreateSphere(pairSpheres[armoredGreySphere], 1);
        CreateSphere(pairSpheres[armoredOrangeSphere], 1);
        yield return new WaitForSeconds(20);
        StartCoroutine(Wave1());
        StopCoroutine(Wave0());

    }

    private IEnumerator Wave1()
    {
        yield return new WaitForSeconds(10);
        CreateSphere(pairSpheres[simpleSphere], 15);
        CreateSphere(pairSpheres[armoredOrangeSphere], 5);
        CreateSphere(pairSpheres[armoredGreySphere], 2);
        CreateSphere(pairSpheres[newspaperSphere], 2);
        yield return new WaitForSeconds(5);
        CreateSphere(pairSpheres[armoredGreySphere], 1);
        CreateSphere(pairSpheres[simpleSphere], 5);
        CreateSphere(pairSpheres[armoredSportmanSphere], 1);
        CreateSphere(pairSpheres[polemanSphere], 2);
        CreateSphere(pairSpheres[simpleSphere], 5);
        CreateSphere(pairSpheres[armoredSportmanSphere], 2);
        CreateSphere(pairSpheres[newspaperSphere], 2);
        CreateSphere(pairSpheres[boxExplodeSphere], 2);
        yield return new WaitForSeconds(10);
        CreateSphere(spheres[1], 1);
        CreateSphere(pairSpheres[simpleSphere], 4);
        CreateSphere(pairSpheres[simpleSphere], 2);
        CreateSphere(pairSpheres[simpleSphere], 6);
        CreateSphere(pairSpheres[armoredSportmanSphere], 1);
        CreateSphere(pairSpheres[armoredSportmanSphere], 1);
        CreateSphere(pairSpheres[boxExplodeSphere], 2);
        CreateSphere(pairSpheres[armoredSportmanSphere], 1);
        yield return new WaitForSeconds(5);
        CreateSphere(pairSpheres[armoredSportmanSphere], 2);
        CreateSphere(pairSpheres[armoredSportmanSphere], 1);
        CreateSphere(pairSpheres[armoredSportmanSphere], 1);
        CreateSphere(pairSpheres[boxExplodeSphere], 1);
        CreateSphere(pairSpheres[boxExplodeSphere], 4);
        CreateSphere(pairSpheres[armoredGreySphere], 3);
        CreateSphere(pairSpheres[armoredGreySphere], 2);
        yield return new WaitForSeconds(10);
        CreateSphere(pairSpheres[newspaperSphere], 3);
        CreateSphere(pairSpheres[armoredSportmanSphere], 1);
        CreateSphere(pairSpheres[polemanSphere], 1);
        CreateSphere(pairSpheres[newspaperSphere], 1);
        CreateSphere(pairSpheres[armoredSportmanSphere], 1);
        yield return new WaitForSeconds(5);
        CreateSphere(pairSpheres[armoredSportmanSphere], 2);
        CreateSphere(pairSpheres[armoredSportmanSphere], 1);
        CreateSphere(pairSpheres[polemanSphere], 1);
        CreateSphere(pairSpheres[armoredSportmanSphere], 1);
        CreateSphere(pairSpheres[boxExplodeSphere], 1);
        CreateSphere(pairSpheres[boxExplodeSphere], 4);
        CreateSphere(pairSpheres[armoredGreySphere], 3);
        CreateSphere(pairSpheres[armoredGreySphere], 2);
        CreateSphere(pairSpheres[polemanSphere], 1);
        yield return new WaitForSeconds(10);
        CreateSphere(pairSpheres[simpleSphere], 15);
        CreateSphere(pairSpheres[armoredOrangeSphere], 10);
        CreateSphere(pairSpheres[armoredGreySphere], 7);
        CreateSphere(pairSpheres[newspaperSphere], 2);
        CreateSphere(pairSpheres[newspaperSphere], 5);
        CreateSphere(pairSpheres[armoredSportmanSphere], 3);
        CreateSphere(pairSpheres[armoredSportmanSphere], 6);
        CreateSphere(pairSpheres[polemanSphere], 2);
        CreateSphere(pairSpheres[armoredSportmanSphere], 3);
        CreateSphere(pairSpheres[polemanSphere], 1);
        yield return new WaitForSeconds(5);


    }

    private void CreateSphere(GameObject sphere, int spheresAmount)
    {
        for(int i=0; i < spheresAmount; i++)
        {
            randomEnemyPoint = Random.Range(0, 5);
            GameObject newSphere = Instantiate(sphere, enemyPoints[randomEnemyPoint].position, enemyPoints[randomEnemyPoint].rotation, spheresParent);
        }
    }

    private void AddSpheresToDictionary()
    {
        pairSpheres.Add(simpleSphere, spheres[0]);
        pairSpheres.Add(armoredOrangeSphere, spheres[1]);
        pairSpheres.Add(armoredGreySphere, spheres[2]);
        pairSpheres.Add(newspaperSphere, spheres[3]);
        pairSpheres.Add(polemanSphere, spheres[4]);
        pairSpheres.Add(boxExplodeSphere, spheres[5]);
        pairSpheres.Add(armoredSportmanSphere, spheres[6]);
    }


}
