using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;

public class CubeFactory : MonoBehaviour
{
    public static CubeFactory instance;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip plantSound;


    public List<CubeData> cubes = new List<CubeData>();

    [Header("References")]
    [SerializeField] private HudUI hudUI;

    public CubeData currentCube;
    public GameObject currentTransparentCube;
    public GameObject selectedTile;
    [SerializeField] private Transform cubesParent;

    public static event Action OnCubeBuilt;

    private void Awake()
    {
        if (instance == null) { instance = this; } else { Destroy(gameObject); }
    }

   public void BuildCube()
    {
        if (currentCube != null && GameManager.isGamePause == false)
        {
            if (GameManager.currentGold >= currentCube.cost)
            {
                GameObject newCube = Instantiate(currentCube.cubePrefab, selectedTile.transform.position, selectedTile.transform.rotation, cubesParent);
                GameManager.currentGold -= currentCube.cost;
                selectedTile.GetComponent<Tile>().currentCube = newCube;
                audioSource.PlayOneShot(plantSound);
                Destroy(currentTransparentCube);
                OnCubeBuilt?.Invoke();
                currentCube = null;
            }
        }
    }

}
