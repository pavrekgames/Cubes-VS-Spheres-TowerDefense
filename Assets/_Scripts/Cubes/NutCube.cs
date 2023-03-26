using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutCube : BaseCube
{
    [Header("NutCube Attributes")]
    [SerializeField] private SpriteRenderer cubeSpriteRenderer;
    [SerializeField] private Color halfHealthColor;
    [SerializeField] private Color smallHealthColor;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        NutCubeState();
    }

    void NutCubeState()
    {
        if (health <= 250 && health > 150)
        {
            cubeSpriteRenderer.color = halfHealthColor;
        }
        else if (health <= 150)
        {
            cubeSpriteRenderer.color = smallHealthColor;
        }
    }

}
