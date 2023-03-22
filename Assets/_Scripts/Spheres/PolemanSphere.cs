using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using DG.Tweening;

public class PolemanSphere : BaseSphere
{
    [SerializeField] private SpriteRenderer poleRenderer;
    [SerializeField] private bool hasJumped = false;
    [SerializeField] private int jumpSpeed = 1;

    protected override void Start()
    {
        base.Start();
        poleRenderer.enabled = true;
        currentSpeed = sphereData.runSpeed;
        currentState = SphereState.MovePole;
    }

    
    protected override void Update()
    {
        if (currentState == SphereState.Move || currentState == SphereState.MovePole)
        {
            Move();
        }

        UpdateTarget();
        Death();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cube"))
        {
            if (currentState == SphereState.MovePole && hasJumped == false)
            {
               StartCoroutine(JumpOverCube(collision));
            }
        }
    }

    private IEnumerator JumpOverCube(Collider2D cube)
    {
        Vector3 jumpPosition = cube.transform.position;
        jumpPosition = cube.transform.position - new Vector3(0.5f, 0, 0);
        transform.DOMove(jumpPosition, jumpSpeed);

        yield return new WaitForSeconds(jumpSpeed);

        currentState = SphereState.Move;
        poleRenderer.enabled = false;
        hasJumped = true;
        StopCoroutine(JumpOverCube(cube));
    }

    private void UpdateTarget()
    {
        if(hasJumped == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 0.2f, layerMask);

            if(hit.collider != null && currentState == SphereState.Move)
            {
                Debug.Log("Attack");
                currentState = SphereState.Attack;
                currentCube = hit.collider.GetComponent<BaseCube>();
                Attack();
            }
            else if(hit.collider == null && currentState == SphereState.Attack)
            {
                currentState = SphereState.Move;
                currentCube = null;
                StopCoroutine(InflictDamage());
            }

        }
    }

}
