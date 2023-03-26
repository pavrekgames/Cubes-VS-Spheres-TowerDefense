using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperSphere : ArmoredSphere
{
    [Header("NewspaperSphere Attributes")]
    [SerializeField] private float fastFrequency = 0.5f;

    protected override void Update()
    {
        base.Update();
    }

    protected override void UpdateSphereState()
    {
        if (health <= 100 && armorSpriteRenderer.enabled == true)
        {
            armorSpriteRenderer.enabled = false;
            currentSpeed = runSpeed;
            attackFrequency = fastFrequency;
        }
    }

}
