using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    [Header("Enemy")]
    [SerializeField] private GameObject enemy;
    
    [Header("Movement")]
    [Range(0, 10)] [SerializeField] private float speed;
    [Range(0, 100)] [SerializeField] private float idleTime;

    private Vector3 _initScale;
    private bool _movingLeft;
    private float _idleTimer;
    private Rigidbody2D _rigidBody;
    

    private void Awake()
    {
        _initScale = enemy.transform.localScale;
        _rigidBody = enemy.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_movingLeft)
        {
            if (enemy.transform.position.x >= leftEdge.position.x)
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
            if (enemy.transform.position.x <= rightEdge.position.x)
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
        enemy.transform.localScale = new Vector3(Mathf.Abs(_initScale.x) * direction, _initScale.y, _initScale.z);
        
        //enemy.transform.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y, enemy.position.z);
        _rigidBody.linearVelocity = new Vector2(direction*speed, 0);
    }
}
