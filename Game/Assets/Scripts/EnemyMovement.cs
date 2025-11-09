using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public int enemyHealth;
    public int enemySpeed;
    public int enemyViewRange;
    public float attackRange;
    public GameObject targetToFollow;

    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetToFollow = GameObject.FindWithTag("Player");
    }

    public void DamageToEnemy()
    {
        if (enemyHealth <= 0)
        {
            //Destroy(GameObject);
        }
    }
    public void AttackPlayer() { }
    public void Update()
    {
        if (Vector2.Distance(transform.position, targetToFollow.transform.position) == attackRange)
        {
            AttackPlayer();
            _animator.SetBool("isPlayerClose", true);
        }
        else if (Vector2.Distance(transform.position, targetToFollow.transform.position) < enemyViewRange)//follow
        {
            transform.position = Vector2.MoveTowards(transform.position, targetToFollow.transform.position, enemySpeed * Time.deltaTime);
            _animator.SetBool("isPlayerClose", true);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            _animator.SetBool("isPlayerClose", false);
        }
    }
}