using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSphere : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRender;
    [SerializeField] protected SphereData sphereData;
    [SerializeField] protected SphereFactory sphereFactory;

    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected float attackFrequency;

    [SerializeField] protected float currentSpeed;
    [SerializeField] protected float walkSpeed;
    [SerializeField] protected float runSpeed;

    [SerializeField] protected BaseCube currentCube;
    [SerializeField] protected LayerMask layerMask;

    public enum SphereState
    {
        Move,
        MovePole,
        Attack
    }

    public SphereState currentState = SphereState.Move;

    protected virtual void Start()
    {
        spriteRender.color = sphereData.color;
        health = sphereData.health;
        damage = sphereData.damage;
        attackFrequency = sphereData.attackFrequency;

        walkSpeed = sphereData.walkSpeed;
        runSpeed = sphereData.runSpeed;
        currentSpeed = sphereData.walkSpeed;

        sphereFactory = SphereFactory.instance;

    }

    protected virtual void Update()
    {
        if (currentState == SphereState.Move)
        {
            Move();
        }

        Death();

    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime, Space.World);
    }

    protected virtual void Attack()
    {

        StartCoroutine(InflictDamage());

    }

    protected virtual IEnumerator InflictDamage()
    {
        while (currentState == SphereState.Attack)
        {
            if (currentCube != null)
            {
                Debug.Log("Inflict Damage");
                currentCube.ReceiveDamage(damage);
                yield return new WaitForSeconds(attackFrequency);
            }
            
        } 
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
    }

    protected virtual void Death()
    {
        if(health <= 0) { Destroy(gameObject); }
    }

    

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cube"))
        {
            if (currentState == SphereState.Move)
            {
                currentState = SphereState.Attack;
                currentCube = collision.GetComponent<BaseCube>();
                Attack();
            }
        } 
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (currentState == SphereState.Attack)
        {
            currentState = SphereState.Move;
            currentCube = null;
            StopCoroutine(InflictDamage());
        }
    }

    public void FreezeState()
    {
        spriteRender.color = sphereData.frezzeColor;
        walkSpeed = sphereData.freezeWalkSpeed;
        runSpeed = sphereData.freezeRunSpeed;
        currentSpeed = walkSpeed;
        attackFrequency = sphereData.freezeAttackFrequency;
    }

}
