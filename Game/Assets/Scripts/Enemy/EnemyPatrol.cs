using System;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    
    [Header("Movement")]
    [Range(0, 10)] [SerializeField] private float speed;
    [Range(0, 100)] [SerializeField] private float idleTime;

    private Vector3 _initScale;
    private bool _movingLeft;
    private float _idleTimer;

    private void Awake()
    {
        _initScale = enemy.localScale;
    }

    private void Update()
    {
        if (_movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                ChangeDirection();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                ChangeDirection();
            }
        }
    }

    private void ChangeDirection()
    {
        _idleTimer += Time.deltaTime;

        if (_idleTimer > idleTime)
        {
            _movingLeft = !_movingLeft;
        }
    }

    private void MoveInDirection(int direction)
    {
        _idleTimer = 0;
        enemy.localScale = new Vector3(Mathf.Abs(_initScale.x) * direction, _initScale.y, _initScale.z);
        
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y, enemy.position.z);
    }
}
