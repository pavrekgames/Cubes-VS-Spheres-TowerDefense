using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;

public class CubeFactoryTest : MonoBehaviour
{
    public static CubeFactoryTest instance;

    public List<CubeData> cubes = new List<CubeData>();

    [Header("References")]
    [SerializeField] private HudUI hudUI;

    public CubeData currentCube;
    public GameObject selectedTile;
    [SerializeField] private Transform cubesParent;

    public static event Action OnCubeBuilt;

    private void Awake()
    {
        if (instance == null) { instance = this; } else { Destroy(gameObject); }
    }

   public void BuildCube()
    {
        if (currentCube != null)
        {
            if (GameManager.currentGold >= currentCube.cost)
            {
                GameObject newCube = Instantiate(currentCube.cubePrefab, selectedTile.transform.position, selectedTile.transform.rotation, cubesParent);
                GameManager.currentGold -= currentCube.cost;
                selectedTile.GetComponent<Tile>().currentCube = currentCube.cubePrefab;
                OnCubeBuilt?.Invoke();
                currentCube = null;
            }
        }
    }

}
