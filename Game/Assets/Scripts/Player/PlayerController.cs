using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [Range(0, 10)] [SerializeField] private float moveSpeed;
    [Range(0, 10)] [SerializeField] private float jumpForce;
    
    [Header("Components")]
    [SerializeField] private InputAction playerMovement;
    [SerializeField] private InputAction playerJump;
    [SerializeField] private LayerMask groundLayer;
    
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _collider;
    private Animator _playerAnimator;
    private bool _facingRight = true;
    

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        EnableMovement();
    }

    void Update()
    {
        Move();
    }

    private void EnableMovement()
    {
        playerMovement.Enable();
        playerJump.Enable();
    }

    private void Move()
    {
        var moveInput = playerMovement.ReadValue<Vector2>();
        var jumpInput = playerJump.IsPressed();
        
        // Flipping player when changing direction
        if (moveInput.x < 0 && _facingRight)
        {
            Flip();
        } 
        else if (moveInput.x > 0 && !_facingRight)
        {
            Flip();
        }
        
        _playerAnimator.SetBool("walking", moveInput.x != 0);
        _playerAnimator.SetBool("grounded", isGrounded());
        _rigidBody.linearVelocity = new Vector2(moveInput.x * moveSpeed, _rigidBody.linearVelocity.y);
        
        if (jumpInput && isGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidBody.linearVelocity = new Vector2(_rigidBody.linearVelocityX, jumpForce);
        _playerAnimator.SetTrigger("jump");
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        
        var locScale = transform.localScale;
        locScale.x *= -1;
        transform.localScale = locScale;
    }

    private bool isGrounded()
    {
        var hitGround = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, 0.05f, groundLayer);
        return hitGround.collider is not null;
    }
}
