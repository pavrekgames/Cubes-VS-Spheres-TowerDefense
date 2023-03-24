using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCube : BaseCube
{
    [SerializeField] private GameObject cubeCurrency;
    [SerializeField] private float spawnForce = 5f;
    [SerializeField] private int cubeDirectionIndex = 1;
    
   protected override void Start()
    {
        base.Start();
        spawnForce = 5f;
    }

    protected override void Update()
    {
        base.Update();
        Countdown();
    }

    void ProduceCurrency()
    {
            GameObject newCubeCurrency = Instantiate(cubeCurrency, transform.position, Quaternion.identity);
            cubeDirectionIndex = Random.Range(1, 4);
            spawnForce = Random.Range(5, 11);
            SetCubeDirection(newCubeCurrency);
            countdown = Random.Range(cubeData.countdown, 5); 
    }

    void Countdown()
    {
        if(countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            ProduceCurrency();
        }
    }

    void SetCubeDirection(GameObject cubeCurrency)
    {
        switch (cubeDirectionIndex)
        {
            case 1:
                cubeCurrency.GetComponent<Rigidbody2D>().AddForce(Vector2.down * spawnForce);
                break;
            case 2:
                cubeCurrency.GetComponent<Rigidbody2D>().AddForce(Vector2.left * spawnForce);
                break;
            case 3:
                cubeCurrency.GetComponent<Rigidbody2D>().AddForce(Vector2.right * spawnForce);
                break;
        }
    }

}
