using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private CubeFactoryTest cubeFactory;
    public GameObject currentCube;
    void Start()
    {
        cubeFactory = CubeFactoryTest.instance;
    }

    private void OnMouseEnter()
    {
        cubeFactory.selectedTile = this.gameObject;
        //Debug.Log("Enter");
    }

    private void OnMouseDown()
    {
        if(currentCube == null)
        {
            cubeFactory.BuildCube();
        }

    }

    private void OnMouseExit()
    {
        cubeFactory.selectedTile = null;
        //Debug.Log("Exit");
    }
}
