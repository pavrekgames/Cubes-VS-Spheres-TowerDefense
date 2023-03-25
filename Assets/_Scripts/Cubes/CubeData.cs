using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Cube",menuName ="CubeTurret")]
public class CubeData : ScriptableObject
{
    public float health;
    public int cost;
    public float timeToBuy;
    public float startTimeToBuy;
    public float countdown;
    public GameObject cubePrefab;
    public GameObject transparentPrefab;
   
}
