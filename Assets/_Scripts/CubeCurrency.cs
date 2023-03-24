using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeCurrency : MonoBehaviour
{
    public const int currencyValue = 25;

    [SerializeField] private bool isCubeStopped = false;
    [SerializeField] private float maxCountdown = 10f;
    [SerializeField] private float countdown = 10f;
    [SerializeField] private Rigidbody2D cubeRigidbody2D;

    public static event Action OnGoldCubeCollected;

    private void Start()
    {
        isCubeStopped = false;
        countdown = maxCountdown;
        cubeRigidbody2D.constraints = RigidbodyConstraints2D.None;
    }

    private void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }

        if (isCubeStopped == false && countdown <= 5)
        {
            isCubeStopped = true;
            cubeRigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else if (isCubeStopped == true && countdown <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnMouseDown()
    {
        if(GameManager.isGamePause == false)
        {
            GameManager.currentGold += currencyValue;
            OnGoldCubeCollected?.Invoke();
            Destroy(gameObject);
        }
       
    }
    
}
