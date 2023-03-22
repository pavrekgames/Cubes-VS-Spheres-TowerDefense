using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredSphere : BaseSphere
{

    [SerializeField] protected SpriteRenderer armorSpriteRenderer;

    protected override void Start()
    {
        base.Start();
        armorSpriteRenderer.enabled = true;
    }

    protected override void Update()
    {
        base.Update();
        SphereState();

    }

    protected virtual void SphereState()
    {
        if(health <= 100 && armorSpriteRenderer.enabled == true)
        {
            armorSpriteRenderer.enabled = false;
        }
    }

}
