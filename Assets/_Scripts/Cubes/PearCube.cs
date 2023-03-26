using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearCube : BaseCube
{
    [Header("PearCube Attributes")]
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool hasTarget = false;
    [SerializeField] private float pearSpeed = 5f;
    public Collider2D[] rangeCheck;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("UpdateTarget", 0, countdown);
    }

    protected override void Update()
    {
        base.Update();
        MoveToTarget();
    }

    private void UpdateTarget()
    {
        if (hasTarget == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 2, layerMask);

            if (hit.collider != null)
            {
                if (rangeCheck.Length == 0)
                {
                    rangeCheck = new Collider2D[1];
                    rangeCheck[0] = hit.collider.gameObject.GetComponent<Collider2D>();
                    hasTarget = true;
                }

            }

        }

    }

    private void MoveToTarget()
    {
        if (hasTarget == true)
        {
            float distance = Vector2.Distance(rangeCheck[0].transform.position, transform.position);
            Vector2 target = rangeCheck[0].transform.position - transform.position;

            if (distance > 0.2f)
            {
                transform.Translate(target * pearSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                KillEnemies();
            }
        }
    }

    private void KillEnemies()
    {
        rangeCheck = Physics2D.OverlapCircleAll(transform.position, 0.5f, layerMask);

        if (rangeCheck.Length != 0)
        {
            foreach (var enemy in rangeCheck)
            {
                Destroy(enemy.gameObject);
            }

            Destroy(gameObject);

        }
    }

}
