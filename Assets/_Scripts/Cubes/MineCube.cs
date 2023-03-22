using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCube : BaseCube
{
    [SerializeField] private SpriteRenderer mineSpriteRenderer;
    [SerializeField] private Color readyMineColor;
    [SerializeField] private LayerMask layerMask;

    public enum MineState
    {
        SleepMine,
        ReadyMine
    }

    public MineState currentMineState = MineState.SleepMine;

    protected override void Update()
    {
        base.Update();
        Countdown();
       
    }

    private void Countdown()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }

        else if (countdown <= 0 && currentMineState == MineState.SleepMine)
        {
            SetReadyMine();
        }
    }

    private void SetReadyMine()
    {
        currentMineState = MineState.ReadyMine;
        mineSpriteRenderer.color = readyMineColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sphere") && currentMineState == MineState.ReadyMine)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
