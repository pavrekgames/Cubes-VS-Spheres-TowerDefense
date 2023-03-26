using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SphereEnemy", menuName = "SphereEnemy")]
public class SphereData : ScriptableObject
{
    [Header("Basic")]
    public GameObject spherePrefab;
    public Color color;
    public int health;
    public int damage;
    public float attackFrequency;

    [Header("Speed")]
    public float walkSpeed;
    public float runSpeed;

    [Header("Freeze State")]
    public Color frezzeColor;
    public float freezeWalkSpeed;
    public float freezeRunSpeed;
    public float freezeAttackFrequency;

}
