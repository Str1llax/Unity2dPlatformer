using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement")]
    [Range(0, 10)] [SerializeField] private float moveSpeed;
    [SerializeField] private int viewRange;
    
    [Header("Health")]
    [Range(0, 10)] [SerializeField] private float health;
    
    [Header("Attack")]
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;
    
    [Header("Misc")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float viewColliderDistance;
    [SerializeField] private float attackColliderDistance;
    
    private Animator _animator;
    private float _cooldownTimer = Mathf.Infinity;
    private Health _playerHealth;
    private EnemyPatrol _enemyPatrol;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyPatrol = GetComponentInParent<EnemyPatrol>();
        _playerHealth = GetComponent<Health>();
    }
    private void Update()
    {
        _cooldownTimer +=  Time.deltaTime;

        if (PlayerInSight())
        {
            _animator.SetBool("playerInSightArea", true);
            if (PlayerInAttackArea() && _cooldownTimer >= attackCooldown)
            {
                _cooldownTimer = 0;
                Attack();
            }
            else
            {
                //TODO ApproachPlayer();
            }
        }
        else
        {
            _animator.SetBool("playerInSightArea", false);
        }

        if (_enemyPatrol is not null)
        {
            
            _enemyPatrol.enabled = !PlayerInSight();
        }
    }

    private bool PlayerInSight()
    {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * (transform.localScale.x * viewRange * viewColliderDistance),
            new Vector3(boxCollider.bounds.size.x * viewRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0f, Vector2.left, 0f, playerLayer);
        return hit.collider is not null;
    }
    
    private bool PlayerInAttackArea()
    {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * (transform.localScale.x * attackRange * attackColliderDistance),
            new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0f, Vector2.left, 0f, playerLayer);

        if (hit.collider is not null)
        {
            _playerHealth = hit.transform.GetComponent<Health>();
        }
        
        return hit.collider is not null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blueViolet;
        Gizmos.DrawCube(boxCollider.bounds.center + transform.right * transform.localScale.x * viewRange * viewColliderDistance,
            new Vector3(boxCollider.bounds.size.x * viewRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxCollider.bounds.center + transform.right * transform.localScale.x * attackRange * attackColliderDistance,
            new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void Attack()
    {
        if (PlayerInAttackArea())
        {
            _playerHealth.TakeDamage(attackDamage);
        }
    }

    private void PlayTransitionSound(AudioClip clip)
    {
        SoundManager.Instance.PlaySound(clip);
    }
}