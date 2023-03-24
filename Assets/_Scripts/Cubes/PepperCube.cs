using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperCube : BaseCube
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform pepperBomb;
    [SerializeField] private GameObject explodeAudioSource;
    protected override void Update()
    {
        base.Update();

        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(KillEnemies());
                
        }

    }

    private IEnumerator KillEnemies()
    {
        pepperBomb.localScale = new Vector2(25, pepperBomb.transform.localScale.y);
        yield return new WaitForSeconds(0.5f);

        Collider2D[] rangeCheck = Physics2D.OverlapBoxAll(transform.position, new Vector2(100,1), 0, layerMask);

        if (rangeCheck.Length != 0)
        {
            foreach (var enemy in rangeCheck)
            {
                Destroy(enemy.gameObject);
            }
        }

        StopCoroutine(KillEnemies());
        GameObject newAudioSource = Instantiate(explodeAudioSource, transform.position, transform.rotation);
        Destroy(gameObject);

    }

}
