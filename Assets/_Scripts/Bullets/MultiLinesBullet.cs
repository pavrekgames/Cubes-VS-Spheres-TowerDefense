using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLinesBullet : MonoBehaviour
{
    [SerializeField] private int damage;
    public int bulletSpeed;
    public Transform lineTarget;
    [SerializeField] private bool hasLineTarget = false;

    private void Start()
    {
        hasLineTarget = false;
    }
    private void Update()
    {
        if(lineTarget != null)
        {
            float distance = Vector2.Distance(lineTarget.position, transform.position);
            Vector2 lineDirection = lineTarget.position - transform.position;

            if (distance > 0.2f && hasLineTarget == false)
            {
                transform.Translate(lineDirection * bulletSpeed * Time.deltaTime, Space.World);
            }
            else if (distance <= 0.2f && hasLineTarget == false)
            {
                hasLineTarget = true;
            }

            if(hasLineTarget == true)
            {
                transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime, Space.World);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseSphere>())
        {
            collision.GetComponent<BaseSphere>().ReceiveDamage(damage);
        }

        lineTarget = null;
        Destroy(gameObject);

    }
}
