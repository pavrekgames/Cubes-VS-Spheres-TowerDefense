using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryCube : BaseCube
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform cherryBomb;
    [SerializeField] private GameObject explodeAudioSource;
    protected override void Update()
    {
        base.Update();

        if(countdown > 0)
        {
            countdown -= Time.deltaTime;
            cherryBomb.localScale = cherryBomb.localScale += new Vector3(0.01f,0.01f, 0f);
        }
        else
        {
            KillEnemies();
        }

    }

    private void KillEnemies()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, 3f, layerMask);

        if (rangeCheck.Length != 0)
        {
            foreach (var enemy in rangeCheck)
            {
                Destroy(enemy.gameObject);
            }  

        }

        GameObject newAudioSource = Instantiate(explodeAudioSource, transform.position, transform.rotation);
        Destroy(gameObject);

    }

}
