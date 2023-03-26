using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCube : BaseCube
{
    [Header("MineCube Attributes")]
    [SerializeField] private SpriteRenderer mineSpriteRenderer;
    [SerializeField] private Color readyMineColor;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject explodeAudioSource;

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
            KillEnemy(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Sphere") && currentMineState == MineState.ReadyMine)
        {
            KillEnemy(collision);
        }
    }

    private void KillEnemy(Collider2D enemy)
    {
        GameObject newAudioSource = Instantiate(explodeAudioSource, transform.position, transform.rotation);
        Destroy(enemy.gameObject);
        Destroy(gameObject);
    }

}
