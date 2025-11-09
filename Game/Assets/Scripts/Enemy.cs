using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public int enemyHealth;
    public int enemySpeed;
    public int enemyViewRange;
    public float attackRange;
    public GameObject targetToFollow;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetToFollow = GameObject.FindWithTag("Player");
    }

    void Update()
    {
            float distanceToPlayer = Vector2.Distance(transform.position, targetToFollow);
            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
            else if (distanceToPlayer < enemyViewRange && distanceToPlayer < attackRange)
            {
                Follow();
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    public void DamageToEnemy()
    {
        if(enemyHealth <= 0)
        {
            //Destroy(GameObject);
        }
    }
    void AttackPlayer()
    {

    }
    void Follow()
    {
        if (Vector2.Distance(transform.position, targetToFollow.transform.position) < enemyViewRange)
        {
        transform.position = Vector2.MoveTowards(transform.position, targetToFollow.transform.position, enemySpeed * Time.deltaTime);
        }
           
    }
}
