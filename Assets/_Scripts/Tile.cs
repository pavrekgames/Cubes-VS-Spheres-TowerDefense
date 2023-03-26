using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private CubeFactory cubeFactory;
    public GameObject currentCube;

    void Start()
    {
        cubeFactory = CubeFactory.instance;
    }

    private void OnMouseEnter()
    {
        cubeFactory.selectedTile = this.gameObject;
    }

    private void OnMouseDown()
    {
        if (currentCube == null)
        {
            cubeFactory.BuildCube();
        }
    }

    private void OnMouseExit()
    {
        cubeFactory.selectedTile = null;
    }
}
