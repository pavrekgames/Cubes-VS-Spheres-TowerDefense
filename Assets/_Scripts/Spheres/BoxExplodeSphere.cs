using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxExplodeSphere : BaseSphere
{
    [SerializeField] private Transform boxBomb;
    [SerializeField] private int explodeDamage = 50;
    protected override void Death()
    {
        if (health <= 0) { StartCoroutine(Explode()); } 
    }

    private IEnumerator Explode()
    {
        boxBomb.localScale = new Vector2(0.7f, 0.7f);
        yield return new WaitForSeconds(0.5f);

        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, 2f, layerMask);

        if (rangeCheck.Length != 0)
        {
            foreach (var cube in rangeCheck)
            {
                cube.GetComponent<BaseCube>().ReceiveDamage(explodeDamage);
            }
        }

        StopCoroutine(Explode());
        Destroy(gameObject);

    }

}
